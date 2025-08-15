using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using GSWApi.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentRepository _paymentRepo;
    private readonly IConfiguration _config;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PaymentController(
        IPaymentRepository paymentRepo,
        IConfiguration config,
        IHttpContextAccessor httpContextAccessor)
    {
        _paymentRepo = paymentRepo;
        _config = config;
        _httpContextAccessor = httpContextAccessor;
    }

    // ================== VNPAY ==================
    [HttpPost("vnpay-create")]
    public async Task<IActionResult> CreatePayment([FromBody] PaymentRequestDTO model)
    {
        // 1) Auto-generate orderCode nếu FE không truyền hoặc là "string"
        if (string.IsNullOrWhiteSpace(model.OrderId) ||
            model.OrderId.Trim().Equals("string", StringComparison.OrdinalIgnoreCase))
        {
            // Ví dụ: ORD-20250814-063735-AB12
            var suffix = Guid.NewGuid().ToString("N").Substring(0, 4).ToUpperInvariant();
            model.OrderId = $"ORD-{DateTime.Now:yyyyMMdd-HHmmss}-{suffix}";
        }
        var orderCode = model.OrderId.Trim();

        // 2) Lấy userId (nếu có), guest => null
        var userId = User?.FindFirstValue(ClaimTypes.NameIdentifier);

        // 3) Tạo/lấy đơn tạm theo orderCode (idempotent ở repository)
        var order = await _paymentRepo.FindOrderByCodeAsync(orderCode)
                  ?? await _paymentRepo.CreateProvisionalOrderAsync(
                        orderCode, userId, model.Amount, model.BuyerEmail, model.BuyerName);

        // 4) Nếu đơn đã thanh toán/đã fail thì không cho tạo tiếp
        if (string.Equals(order.Status, "Success", StringComparison.OrdinalIgnoreCase))
            return Conflict(new { message = "Order already paid." });

        if (string.Equals(order.Status, "Failed", StringComparison.OrdinalIgnoreCase))
            return Conflict(new { message = "Order was marked as failed. Please create a new order." });

        // 5) Idempotent cho transaction:
        //    Nếu đã có transaction Pending cho order này thì reuse, không tạo bản ghi mới.
        var latestTx = await _paymentRepo.GetByOrderCodeAsync(orderCode);
        if (latestTx != null && string.Equals(latestTx.Status, "Pending", StringComparison.OrdinalIgnoreCase))
        {
            string hostName = System.Net.Dns.GetHostName();
            string clientIP = System.Net.Dns.GetHostAddresses(hostName).GetValue(0).ToString();
            string reuseUrl = VnPayHelper.CreatePaymentUrl(model, _config, clientIP);

            return Ok(new PaymentResponseDTO
            {
                PaymentUrl = reuseUrl,
                OrderId = orderCode,
                Message = "Payment is pending. Reusing existing transaction."
            });
        }

        // 6) Chưa có Pending -> tạo transaction mới
        var transaction = new PaymentTransaction
        {
            StoreOrderId = order.ID,
            GatewayOrderId = orderCode,       // vnp_TxnRef
            Amount = model.Amount,
            PaymentMethod = "VNPAY",
            Status = "Pending",
            CreatedAt = DateTime.Now
        };
        await _paymentRepo.CreateTransactionAsync(transaction);

        // 7) Build URL VNPay
        string host = System.Net.Dns.GetHostName();
        string clientIPAddress = System.Net.Dns.GetHostAddresses(host).GetValue(0).ToString();
        string paymentUrl = VnPayHelper.CreatePaymentUrl(model, _config, clientIPAddress);

        return Ok(new PaymentResponseDTO
        {
            PaymentUrl = paymentUrl,
            OrderId = orderCode,
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

        await _paymentRepo.UpdateOrderStatusByCodeAsync(orderId, transaction.Status);

        if (isSuccess)
        {
            try
            {
                await _paymentRepo.GrantGameToLibraryAsync(orderId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GrantGameToLibraryAsync error for order {orderId}: {ex}");
            }
        }

        var feUrl = $"http://localhost:5000/payment/result?orderId={orderId}&status={transaction.Status.ToLower()}";
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
            await _paymentRepo.GrantGameToLibraryAsync(orderId);
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
