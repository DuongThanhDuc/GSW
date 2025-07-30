using System.Web;
using Azure.Core;
using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using GSWApi.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentRepository _paymentRepo;
    private readonly IConfiguration _config;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PaymentController(IPaymentRepository paymentRepo, IConfiguration config,
        IHttpContextAccessor httpContextAccessor)
    {
        _paymentRepo = paymentRepo;
        _config = config;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost("vnpay-create")]
    public async Task<IActionResult> CreatePayment([FromBody] PaymentRequestDTO model)
    {
        // Kiểm tra và tự sinh OrderId nếu không có
        if (string.IsNullOrEmpty(model.OrderId) || model.OrderId.Trim().ToLower() == "string")
        {
            model.OrderId = Guid.NewGuid().ToString("N").Substring(0, 10);
        }

        // Tạo giao dịch thanh toán
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
            Message = "Tạo thanh toán thành công, vui lòng quét mã QR hoặc nhấn vào link để thanh toán."
        });
    }

    [HttpGet("vnpay-callback")]
    public async Task<IActionResult> VnPayCallback()
    {
        // Extract the query string from the request
        var queryString = Request.QueryString.Value;

        // Parse the query string into a dictionary (key-value pairs)
        var json = HttpUtility.ParseQueryString(queryString);

        // Retrieve necessary parameters from the query string
        string orderId = json["vnp_TxnRef"]; // Order ID
        string orderInfor = json["vnp_OrderInfo"]; // Order info (description)
        long vnpayTranId = Convert.ToInt64(json["vnp_TransactionNo"]); // VnPay transaction ID
        string vnp_ResponseCode = json["vnp_ResponseCode"]; // Response code from VnPay
        string vnp_SecureHash = json["vnp_SecureHash"]; // Secure hash from VnPay

        // Calculate the position where the SecureHash ends in the query string
        var pos = queryString.IndexOf("&vnp_SecureHash");

        // Fetch the secret key from the configuration
        var hashSecret = _config["VnPay:HashSecret"];

        // Validate the signature using the query string and VnPay's secure hash
        bool isValid = VnPayHelper.ValidateSignature(queryString.Substring(1, pos - 1), vnp_SecureHash, hashSecret);

        // If the signature is not valid, return a BadRequest response
        if (!isValid)
            return BadRequest("Invalid signature!");

        // If the signature is valid, proceed to handle the transaction result
        var responseCode = json["vnp_ResponseCode"]; // Response code from VnPay

        // Get the transaction from the repository using the order ID
        var transaction = await _paymentRepo.GetByOrderIdAsync(orderId.ToString());

        // If no transaction is found, return NotFound
        if (transaction == null)
            return NotFound("Transaction not found");

        // Update the transaction status based on the response code
        if (responseCode == "00")
        {
            // Payment was successful
            transaction.Status = "Success";
        }
        else
        {
            // Payment failed
            transaction.Status = "Failed";
        }

        // Serialize the entire response for logging or further processing
        transaction.PaymentGatewayResponse = JsonConvert.SerializeObject(Request.Query);

        // Update the transaction in the database
         await _paymentRepo.UpdateTransactionAsync(transaction);

        // Return a success message after processing the transaction
        // Return URL FE
        return Ok("Transaction has been processed.");
    }

    [HttpGet("vnpay-ipn")]
    public async Task<IActionResult> VnPayIpn([FromQuery] VnPayCallbackDTO callback)
    {
        var hashSecret = _config["VnPay:HashSecret"];

        // 1. Tạo chuỗi dữ liệu cần ký lại (bỏ trường vnp_SecureHash & vnp_SecureHashType ra)
        var query = HttpContext.Request.Query;
        var sorted = query.Where(kv => kv.Key != "vnp_SecureHash" && kv.Key != "vnp_SecureHashType")
                          .OrderBy(kv => kv.Key)
                          .Select(kv => $"{kv.Key}={kv.Value}")
                          .ToArray();

        string rspraw = string.Join("&", sorted);

        // 2. Lấy giá trị hash gốc
        string inputHash = HttpContext.Request.Query["vnp_SecureHash"];


        // 3. Gọi hàm kiểm tra
        var isValid = VnPayHelper.ValidateSignature(rspraw, inputHash, hashSecret);

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

    [HttpPost("momo-create")]
    public async Task<IActionResult> CreateMomoPayment([FromBody] MomoPaymentRequestDTO model)
    {
        if (string.IsNullOrEmpty(model.OrderId) || model.OrderId.Trim().ToLower() == "string")
        {
            model.OrderId = Guid.NewGuid().ToString("N").Substring(0, 10);
        }

        // amount: số nguyên (Momo yêu cầu), truyền lên dạng string!
        var amount = Convert.ToInt32(model.Amount).ToString();

        var transaction = new PaymentTransaction
        {
            OrderId = model.OrderId,
            Amount = model.Amount,
            PaymentMethod = "MOMO",
            Status = "Pending",
            CreatedAt = DateTime.Now
        };
        await _paymentRepo.CreateTransactionAsync(transaction);

        var config = _config.GetSection("MomoAPI");
        var partnerCode = config["PartnerCode"];
        var accessKey = config["AccessKey"];
        var secretKey = config["SecretKey"];
        var endpoint = config["MomoApiUrl"];
        var returnUrl = config["ReturnUrl"];
        var notifyUrl = config["NotifyUrl"];
        var requestType = config["RequestType"];
        var orderId = model.OrderId;
        var orderInfo = $"Thanh toán đơn hàng {orderId}";

        var momoResp = await MomoHelper.CreatePaymentAsync(
            endpoint, partnerCode, accessKey, secretKey,
            returnUrl, notifyUrl, amount, orderId, orderInfo, requestType
        );

        if (momoResp.errorCode == 0)
        {
            return Ok(new PaymentResponseDTO
            {
                PaymentUrl = momoResp.payUrl,
                OrderId = orderId,
                Message = "Tạo thanh toán thành công với MOMO!"
            });
        }
        else
        {
            return BadRequest(new { momoResp.errorCode, momoResp.message });
        }
    }


    [HttpGet("status/{orderId}")]
    public async Task<IActionResult> GetPaymentStatus(string orderId)
    {
        var transaction = await _paymentRepo.GetByOrderIdAsync(orderId);
        if (transaction == null) return NotFound();
        return Ok(new { transaction.OrderId, transaction.Status, transaction.CreatedAt });
    }
}