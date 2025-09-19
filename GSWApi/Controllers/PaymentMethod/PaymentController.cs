using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using GSWApi.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentRepository _paymentRepo;
    private readonly IStoreLibraryRepository _storeRepo;
    private readonly IStoreOrderRepository _storeOrderRepo;
    private readonly IStoreOrderDetailRepository _storeOrderDetailRepo;
    private readonly IConfiguration _config;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PaymentController(IPaymentRepository paymentRepo, IStoreLibraryRepository storeRepo,
        IStoreOrderRepository storeOrderRepo, IStoreOrderDetailRepository storeOrderDetailRepo, IConfiguration config,
        IHttpContextAccessor httpContextAccessor)
    {
        _paymentRepo = paymentRepo;
        _storeRepo = storeRepo;
        _storeOrderRepo = storeOrderRepo;
        _storeOrderDetailRepo = storeOrderDetailRepo;
        _config = config;
        _httpContextAccessor = httpContextAccessor;
    }

    // ================== VNPAY ==================
    [HttpPost("vnpay-create")]
    public async Task<IActionResult> CreatePayment([FromBody] PaymentRequestDTO model)
    {
        var orderCode = model.OrderId;
        var suffix = Guid.NewGuid().ToString("N").Substring(0, 4).ToUpperInvariant();
        string order_code = $"ORD-{DateTime.Now:yyyyMMdd-HHmmss}-{suffix}";
        // 2) Lấy userId (nếu có), guest => null
        var userId = User?.FindFirstValue(ClaimTypes.NameIdentifier);

        var lastTransaction = await _paymentRepo.GetByStoreOrderIdAsync(model.OrderId);

        StoreOrder order;
        if (lastTransaction == null)
        {
            order = await _paymentRepo.CreateProvisionalOrderAsync(
                order_code,
                userId,
                model.Amount
            );
        }
        else
        {
            var check = await _storeOrderRepo.GetByIdAsync(model.OrderId);
            if (check == null)
            {
                return BadRequest(new { message = "Order not found." });
            }
            if (string.Equals(check.Status, "Success", StringComparison.OrdinalIgnoreCase))
                return Conflict(new { message = "Order already paid." });

            if (string.Equals(check.Status, "Failed", StringComparison.OrdinalIgnoreCase))
                return Conflict(new { message = "Order was marked as failed. Please create a new order." });
        }

        //    Nếu đã có transaction Pending cho order này thì reuse, không tạo bản ghi mới.
        var latestTx = await _paymentRepo.GetByOrderCodeAsync(orderCode.ToString());
        if (latestTx != null && string.Equals(latestTx.Status, "Pending", StringComparison.OrdinalIgnoreCase))
        {
            string hostName = System.Net.Dns.GetHostName();
            string clientIP = System.Net.Dns.GetHostAddresses(hostName).GetValue(0).ToString();
            string reuseUrl = VnPayHelper.CreatePaymentUrl(model, _config, clientIP, order_code);

            return Ok(new PaymentResponseDTO
            {
                PaymentUrl = reuseUrl,
                OrderId = orderCode.ToString(),
                Message = "Payment is pending. Reusing existing transaction."
            });
        }

        // 6) Chưa có Pending -> tạo transaction mới
        var transaction = new PaymentTransaction
        {
            StoreOrderId = model.OrderId,
            GatewayOrderId = order_code, // vnp_TxnRef
            Amount = model.Amount,
            PaymentMethod = "VNPAY",
            Status = "Pending",
            CreatedAt = DateTime.Now
        };
        await _paymentRepo.CreateTransactionAsync(transaction);

        // 7) Build URL VNPay
        string host = System.Net.Dns.GetHostName();
        string clientIPAddress = System.Net.Dns.GetHostAddresses(host).GetValue(0).ToString();
        string paymentUrl = VnPayHelper.CreatePaymentUrl(model, _config, clientIPAddress, order_code);

        return Ok(new PaymentResponseDTO
        {
            PaymentUrl = paymentUrl,
            OrderId = orderCode.ToString(),
            Message = "Payment created successfully."
        });
    }


    // Người dùng bị redirect về đây sau khi thanh toán
    // (Prod nên chỉ hiển thị/redirect FE; cập nhật trạng thái ưu tiên ở IPN)
    [HttpGet("vnpay-callback")]
    public async Task<IActionResult> VnPayCallback()
    {
        var queryString = Request.QueryString.Value;
        var json = HttpUtility.ParseQueryString(queryString);
        string orderId = json["vnp_TxnRef"];
        string vnp_ResponseCode = json["vnp_ResponseCode"];
        string vnp_SecureHash = json["vnp_SecureHash"];
        var orderInfo = json["vnp_OrderInfo"];
        var pos = queryString.IndexOf("&vnp_SecureHash");
        var hashSecret = _config["VnPay:HashSecret"];

        bool isValid = VnPayHelper.ValidateSignature(queryString.Substring(1, pos - 1), vnp_SecureHash, hashSecret);
        if (!isValid) return BadRequest("Invalid signature!");

        var transaction = await _paymentRepo.GetByOrderCodeAsync(orderId);
        if (transaction == null) return NotFound("Transaction not found");

        bool isSuccess = vnp_ResponseCode == "00";
        transaction.Status = isSuccess ? "Success" : "Failed";
        transaction.PaymentGatewayResponse = JsonConvert.SerializeObject(Request.Query);
        await _paymentRepo.UpdateTransactionAsync(transaction);
        await _storeOrderRepo.UpdateOrderStatusAsync(transaction.StoreOrderId, transaction.Status);
        await _paymentRepo.UpdateOrderStatusByCodeAsync(orderId, transaction.Status);
        int value = int.TryParse(orderInfo, out var result) ? result : 0;

        if (isSuccess)
        {
            try
            {
                await _paymentRepo.GrantGameToLibraryAsync(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GrantGameToLibraryAsync error for order {orderId}: {ex}");
            }
        }

        var feUrl = $"https://gsw-sep.web.app/notifications/{result}/{transaction.Status.ToLower()}";
        return Redirect(feUrl);
    }

    // IPN từ VNPay 
    [HttpGet("vnpay-ipn")]
    public async Task<IActionResult> VnPayIpn([FromQuery] VnPayCallbackDTO callback)
    {
        var hashSecret = _config["VnPay:HashSecret"];

        var query = HttpContext.Request.Query;
        var sorted = query
            .Where(kv => kv.Key != "vnp_SecureHash" && kv.Key != "vnp_SecureHashType")
            .OrderBy(kv => kv.Key)
            .Select(kv => $"{kv.Key}={kv.Value}")
            .ToArray();
        string rspraw = string.Join("&", sorted);

        string inputHash = HttpContext.Request.Query["vnp_SecureHash"];

        var isValid = VnPayHelper.ValidateSignature(rspraw, inputHash, hashSecret);
        if (!isValid) return BadRequest("Invalid signature!");

        var orderId = callback.vnp_TxnRef;
        var transaction = await _paymentRepo.GetByOrderCodeAsync(orderId);
        if (transaction == null) return NotFound("Transaction not found");

        bool isSuccess = callback.vnp_ResponseCode == "00" && transaction.Status != "Success";
        transaction.Status = isSuccess ? "Success" : "Failed";
        transaction.PaymentGatewayResponse = JsonConvert.SerializeObject(callback);
        await _paymentRepo.UpdateTransactionAsync(transaction);

        await _paymentRepo.UpdateOrderStatusByCodeAsync(orderId, transaction.Status);

        if (isSuccess)
        {
            await _paymentRepo.GrantGameToLibraryAsync(transaction.StoreOrderId);
        }

        return Content("responseCode=00");
    }

    // ================== CHECK PAYMENT STATUS ==================

    [HttpGet("status/{orderCode}")]
    public async Task<IActionResult> GetPaymentStatus(string orderCode)
    {
        var transaction = await _paymentRepo.GetByOrderCodeAsync(orderCode);
        if (transaction == null) return NotFound(new { message = "Transaction not found" });

        return Ok(new
        {
            orderCode,
            transaction.Status,
            transaction.CreatedAt
        });
    }
}