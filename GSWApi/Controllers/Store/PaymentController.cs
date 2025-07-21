using Azure.Core;
using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentRepository _paymentRepo;
    private readonly IConfiguration _config;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PaymentController(IPaymentRepository paymentRepo, IConfiguration config, IHttpContextAccessor httpContextAccessor)
    {
        _paymentRepo = paymentRepo;
        _config = config;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreatePayment([FromBody] PaymentRequestDTO model)
    {
        // Nếu client không gửi OrderId, backend tự sinh mã duy nhất!
        if (string.IsNullOrEmpty(model.OrderId) || model.OrderId.Trim().ToLower() == "string")
        {
            model.OrderId = Guid.NewGuid().ToString("N").Substring(0, 10);
        }


        var transaction = new PaymentTransaction
        {
            OrderId = model.OrderId,
            Amount = model.Amount,
            PaymentMethod = "VNPAY",
            Status = "Pending",
            CreatedAt = DateTime.Now
        };
        await _paymentRepo.CreateTransactionAsync(transaction);

        // LẤY IP ADDRESS CHO VNPAY
        string ipAddress = "42.113.119.106";
        var remoteIp = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress;
        if (remoteIp != null && remoteIp.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            ipAddress = remoteIp.ToString();

        // Nếu test local thì nên hardcode ip public nếu VNPAY yêu cầu
        // ipAddress = "xxx.xxx.xxx.xxx"; // điền IP public thực tế

        var url = VnPayHelper.CreatePaymentUrl(model, _config, ipAddress);

        return Ok(new PaymentResponseDTO
        {
            PaymentUrl = url,
            OrderId = model.OrderId,
            Message = "Tạo thanh toán thành công đơn hàng , vui lòng quét mã QR hoặc nhấn vào link."
        });
    }

    [HttpGet("vnpay-callback")]
    public async Task<IActionResult> VnPayCallback([FromQuery] VnPayCallbackDTO callback)
    {
        var hashSecret = _config["VnPay:HashSecret"];
        var isValid = VnPayHelper.ValidateVnpaySignature(Request.Query, hashSecret);

        if (!isValid)
            return BadRequest("Invalid signature!");

        var orderId = callback.vnp_TxnRef;
        var transaction = await _paymentRepo.GetByOrderIdAsync(orderId);
        if (transaction == null) return NotFound("Không tìm thấy giao dịch");

        if (callback.vnp_ResponseCode == "00")
        {
            transaction.Status = "Success";
        }
        else
        {
            transaction.Status = "Failed";
        }
        transaction.PaymentGatewayResponse = JsonConvert.SerializeObject(callback);
        await _paymentRepo.UpdateTransactionAsync(transaction);

        return Ok("Giao dịch đã được xử lý.");
    }

    [HttpGet("vnpay-ipn")]
    public async Task<IActionResult> VnPayIpn([FromQuery] VnPayCallbackDTO callback)
    {
        var hashSecret = _config["VnPay:HashSecret"];
        var isValid = VnPayHelper.ValidateVnpaySignature(Request.Query, hashSecret);

        if (!isValid)
            return BadRequest("Invalid signature!");

        var orderId = callback.vnp_TxnRef;
        var transaction = await _paymentRepo.GetByOrderIdAsync(orderId);
        if (transaction == null) return NotFound("Không tìm thấy giao dịch");

        if (callback.vnp_ResponseCode == "00")
        {
            transaction.Status = "Success";
        }
        else
        {
            transaction.Status = "Failed";
        }
        transaction.PaymentGatewayResponse = JsonConvert.SerializeObject(callback);
        await _paymentRepo.UpdateTransactionAsync(transaction);

        
        return Content("responseCode=00");
    }

    [HttpGet("status/{orderId}")]
    public async Task<IActionResult> GetPaymentStatus(string orderId)
    {
        var transaction = await _paymentRepo.GetByOrderIdAsync(orderId);
        if (transaction == null) return NotFound();
        return Ok(new { transaction.OrderId, transaction.Status, transaction.CreatedAt });
    }

}
