using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using GSWApi.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        // Auto-generate OrderId nếu FE gửi "string" hoặc rỗng
        if (string.IsNullOrEmpty(model.OrderId) || model.OrderId.Trim().ToLower() == "string")
        {
            model.OrderId = Guid.NewGuid().ToString("N").Substring(0, 10);
        }

        // Tạo payment transaction
        var transaction = new PaymentTransaction
        {
            OrderId = model.OrderId,
            Amount = model.Amount,
            PaymentMethod = "VNPAY",
            Status = "Pending",
            CreatedAt = DateTime.Now
        };

        await _paymentRepo.CreateTransactionAsync(transaction);

        string hostName = System.Net.Dns.GetHostName();
        string clientIPAddress = System.Net.Dns.GetHostAddresses(hostName).GetValue(0).ToString();

        string paymentUrl = VnPayHelper.CreatePaymentUrl(model, _config, clientIPAddress);

        return Ok(new PaymentResponseDTO
        {
            PaymentUrl = paymentUrl,
            OrderId = model.OrderId,
            Message = "Payment created successfully. Please scan the QR code or click the link to proceed with payment."
        });
    }

    // Người dùng bị redirect về đây sau khi thanh toán
    // (Prod nên chỉ hiển thị/redirect FE; cập nhật trạng thái ưu tiên ở IPN)
    [HttpGet("vnpay-callback")]
    public async Task<IActionResult> VnPayCallback()
    {
        // Lấy full query string
        var queryString = Request.QueryString.Value;

        // Parse các tham số
        var json = HttpUtility.ParseQueryString(queryString);
        string orderId = json["vnp_TxnRef"];                 // Order ID (chính là OrderCode)
        string vnp_ResponseCode = json["vnp_ResponseCode"];  // "00" = success
        string vnp_SecureHash = json["vnp_SecureHash"];      // Secure hash từ VNPay

        // Vị trí kết thúc phần ký trước vnp_SecureHash
        var pos = queryString.IndexOf("&vnp_SecureHash");
        var hashSecret = _config["VnPay:HashSecret"];

        // Validate signature
        bool isValid = VnPayHelper.ValidateSignature(queryString.Substring(1, pos - 1), vnp_SecureHash, hashSecret);
        if (!isValid) return BadRequest("Invalid signature!");

        // Lấy transaction
        var transaction = await _paymentRepo.GetByOrderIdAsync(orderId);
        if (transaction == null) return NotFound("Transaction not found");

        // Xác định trạng thái
        string status = vnp_ResponseCode == "00" ? "success" : "failed";

        // Cập nhật transaction
        transaction.Status = status == "success" ? "Success" : "Failed";
        transaction.PaymentGatewayResponse = JsonConvert.SerializeObject(Request.Query);
        await _paymentRepo.UpdateTransactionAsync(transaction);

        // (Tùy chọn DEV) Cập nhật Order luôn ở Callback để dễ test local (prod nên dựa vào IPN)
        await _paymentRepo.UpdateOrderStatusByCodeAsync(orderId,
            vnp_ResponseCode == "00" ? "Success" : "Failed");

        // Redirect về FE
        var feUrl = $"http://localhost:5000/payment/result?orderId={orderId}&status={status}";
        return Redirect(feUrl);
    }

    // IPN từ VNPay (nguồn đáng tin cậy để flip trạng thái)
    [HttpGet("vnpay-ipn")]
    public async Task<IActionResult> VnPayIpn([FromQuery] VnPayCallbackDTO callback)
    {
        var hashSecret = _config["VnPay:HashSecret"];

        // 1) Build raw data (bỏ vnp_SecureHash & vnp_SecureHashType)
        var query = HttpContext.Request.Query;
        var sorted = query
            .Where(kv => kv.Key != "vnp_SecureHash" && kv.Key != "vnp_SecureHashType")
            .OrderBy(kv => kv.Key)
            .Select(kv => $"{kv.Key}={kv.Value}")
            .ToArray();
        string rspraw = string.Join("&", sorted);

        // 2) input hash
        string inputHash = HttpContext.Request.Query["vnp_SecureHash"];

        // 3) validate
        var isValid = VnPayHelper.ValidateSignature(rspraw, inputHash, hashSecret);
        if (!isValid) return BadRequest("Invalid signature!");

        var orderId = callback.vnp_TxnRef; // chính là OrderCode
        var transaction = await _paymentRepo.GetByOrderIdAsync(orderId);
        if (transaction == null) return NotFound("Transaction not found");

        if (callback.vnp_ResponseCode == "00" && transaction.Status != "Success")
        {
            transaction.Status = "Success";
            transaction.PaymentGatewayResponse = JsonConvert.SerializeObject(callback);
            await _paymentRepo.UpdateTransactionAsync(transaction);

            //  Cập nhật trạng thái Order
            await _paymentRepo.UpdateOrderStatusByCodeAsync(orderId, "Success");

            //  Cấp game vào thư viện
            await _paymentRepo.GrantGameToLibraryAsync(orderId);
        }
        else
        {
            transaction.Status = "Failed";
            transaction.PaymentGatewayResponse = JsonConvert.SerializeObject(callback);
            await _paymentRepo.UpdateTransactionAsync(transaction);

            //  Đánh fail cho Order
            await _paymentRepo.UpdateOrderStatusByCodeAsync(orderId, "Failed");
        }

        // VNPay yêu cầu trả content xác nhận
        return Content("responseCode=00");
    }

    // ================== CHECK PAYMENT STATUS ==================

    [HttpGet("status/{orderId}")]
    public async Task<IActionResult> GetPaymentStatus(string orderId)
    {
        var transaction = await _paymentRepo.GetByOrderIdAsync(orderId);
        if (transaction == null) return NotFound(new { message = "Transaction not found" });
        return Ok(new { transaction.OrderId, transaction.Status, transaction.CreatedAt });
    }
}
