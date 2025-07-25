﻿using Azure.Core;
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

    public PaymentController(IPaymentRepository paymentRepo, IConfiguration config, IHttpContextAccessor httpContextAccessor)
    {
        _paymentRepo = paymentRepo;
        _config = config;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost("vnpay-create")]
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
        string ipAddress = VnPayHelper.GetClientIpAddress(_httpContextAccessor.HttpContext);


        var url = VnPayHelper.CreatePaymentUrl(model, _config, ipAddress);

        return Ok(new PaymentResponseDTO
        {
            PaymentUrl = url,
            OrderId = model.OrderId,
            Message = "Tạo thanh toán thành công đơn hàng , vui lòng quét mã QR hoặc nhấn vào link."
        });
    }

    [HttpGet("vnpay-callback")]
    public async Task<IActionResult> VnPayCallback()
    {

        // In ra toàn bộ query string
        Console.WriteLine("QueryString received: " + Request.QueryString);
        foreach (var kv in Request.Query)
            Console.WriteLine($"{kv.Key}: {kv.Value}");

        var hashSecret = _config["VnPay:HashSecret"];
        var isValid = VnPayHelper.ValidateVnpaySignature(Request.Query, hashSecret);

        if (!isValid)
            return BadRequest("Invalid signature!");

        var orderId = Request.Query["vnp_TxnRef"].ToString();
        var amount = Request.Query["vnp_Amount"].ToString();
        var responseCode = Request.Query["vnp_ResponseCode"].ToString();

        var transaction = await _paymentRepo.GetByOrderIdAsync(orderId);
        if (transaction == null) return NotFound("Không tìm thấy giao dịch");

        if (responseCode == "00")
        {
            transaction.Status = "Success";
        }
        else
        {
            transaction.Status = "Failed";
        }
        transaction.PaymentGatewayResponse = JsonConvert.SerializeObject(Request.Query);
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
