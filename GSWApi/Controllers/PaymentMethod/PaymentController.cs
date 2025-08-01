using System.Web;
using Azure.Core;
using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Google.Apis.Drive.v3.Data;
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

        // Get the transaction from the repository using the order ID
        var transaction = await _paymentRepo.GetByOrderIdAsync(orderId.ToString());

        // If no transaction is found, return NotFound
        if (transaction == null)
            return NotFound("Transaction not found");

        // Xác định trạng thái
        string status = vnp_ResponseCode == "00" ? "success" : "failed";

        // Cập nhật trạng thái transaction
        transaction.Status = status == "success" ? "Success" : "Failed";
        transaction.PaymentGatewayResponse = JsonConvert.SerializeObject(Request.Query);

        // Update the transaction in the database
        await _paymentRepo.UpdateTransactionAsync(transaction);

        // Build FE URL
        var feUrl = $"http://localhost:5000/payment/result?orderId={orderId}&status={status}";

        // Redirect về FE
        return Redirect(feUrl);
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


    // ================== MOMO ==================

    // Tạo đơn MoMo (sandbox V3)
    [HttpPost("momo-create")]
    public async Task<IActionResult> CreateMomoPayment([FromBody] MomoPaymentRequestDTO model)
    {
        if (string.IsNullOrEmpty(model.OrderId) || model.OrderId.Trim().ToLower() == "string")
        {
            model.OrderId = Guid.NewGuid().ToString("N").Substring(0, 10);
        }

        var config = _config.GetSection("MomoAPI");
        var momoResp = await MomoHelper.CreatePaymentAsync(
            endpoint: config["MomoApiUrl"],
            partnerCode: config["PartnerCode"],
            accessKey: config["AccessKey"],
            secretKey: config["SecretKey"],
            redirectUrl: config["ReturnUrl"],   // redirectUrl
            ipnUrl: config["NotifyUrl"],        // ipnUrl
            amount: Convert.ToInt64(model.Amount),
            orderId: model.OrderId,
            orderInfo: $"Thanh toán đơn hàng {model.OrderId}",
            requestType: config["RequestType"]
        );

        if (momoResp.resultCode == 0)
        {
            return Ok(new
            {
                paymentUrl = momoResp.payUrl,
                message = "Tạo thanh toán thành công với MOMO!",
                orderId = momoResp.orderId
            });
        }
        else
        {
            return BadRequest(new { momoResp.resultCode, momoResp.message });
        }
    }
    // Callback: Khi user thanh toán xong, MoMo redirect về link này (FE dùng GET)
    [HttpGet("momo-callback")]
    public IActionResult MomoCallback([FromQuery] MomoCallbackDTO callback)
    {
        // Có thể redirect về trang FE hoặc trả nội dung luôn tuỳ bạn
        if (callback.resultCode == 0)
            return Redirect($"/payment-success?orderId={callback.orderId}");
        else
            return Redirect($"/payment-failed?orderId={callback.orderId}&message={callback.message}");
        // Nếu muốn test API thuần, có thể trả về Ok:
        // return Ok($"OrderId: {callback.orderId}, Error: {callback.errorCode}, Message: {callback.message}");
    }

    // Xử lý IPN/Notify từ MoMo (khi thanh toán xong MoMo sẽ POST về đây)
    [HttpPost("momo-notify")]
    public async Task<IActionResult> MomoNotify([FromBody] MomoIPNRequestDTO request)
    {
        // build rawData cho signature
        string rawData = $"amount={request.amount}" +
                         $"&extraData={request.extraData}" +
                         $"&message={request.message}" +
                         $"&orderId={request.orderId}" +
                         $"&orderInfo={request.orderInfo}" +
                         $"&orderType={request.orderType}" +
                         $"&partnerCode={request.partnerCode}" +
                         $"&payType={request.payType}" +
                         $"&requestId={request.requestId}" +
                         $"&responseTime={request.responseTime}" +
                         $"&resultCode={request.resultCode}" +
                         $"&transId={request.transId}";

        var secretKey = _config["MomoAPI:SecretKey"];
        var checkSignature = MomoHelper.CreateSignature(rawData, secretKey);

        if (checkSignature != request.signature)
            return BadRequest("Invalid signature");

        var transaction = await _paymentRepo.GetByOrderIdAsync(request.orderId);
        if (transaction == null) return NotFound("Không tìm thấy giao dịch");

        if (transaction.Status == "Success")
            return Ok(new { message = "Already processed" });

        transaction.Status = request.resultCode == 0 ? "Success" : "Failed";
        transaction.PaymentGatewayResponse = JsonConvert.SerializeObject(request);
        await _paymentRepo.UpdateTransactionAsync(transaction);

        return Ok(new
        {
            partnerCode = request.partnerCode,
            orderId = request.orderId,
            requestId = request.requestId,
            resultCode = 0,
            message = "Received",
            responseTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
        });
    }

    // ================== TRA CỨU TRẠNG THÁI ==================

    [HttpGet("status/{orderId}")]
    public async Task<IActionResult> GetPaymentStatus(string orderId)
    {
        var transaction = await _paymentRepo.GetByOrderIdAsync(orderId);
        if (transaction == null) return NotFound();
        return Ok(new { transaction.OrderId, transaction.Status, transaction.CreatedAt });
    }
}