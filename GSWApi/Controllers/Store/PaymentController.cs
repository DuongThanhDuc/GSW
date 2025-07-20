using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using BusinessModel.Model;
using GSW.GSWApi.Utility;
using Newtonsoft.Json;

namespace GSW.GSWApi.Controllers.Store
{
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
            var transaction = new PaymentTransaction
            {
                OrderId = model.OrderId,
                Amount = model.Amount,
                PaymentMethod = "VNPAY",
                Status = "Pending",
                CreatedAt = DateTime.Now
            };
            await _paymentRepo.CreateTransactionAsync(transaction);

            // ==== SỬA ĐOẠN LẤY IP ADDRESS CHO CHUẨN VNPAY ====
            var ipObj = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress;
            string ipAddress = "127.0.0.1";
            if (ipObj != null)
            {
                if (ipObj.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    ipAddress = ipObj.ToString();
                else if (ipObj.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                    ipAddress = "127.0.0.1"; // Bắt buộc về IPv4 nếu là IPv6 local
            }
            // ==== HẾT ĐOẠN SỬA IP ====

            var url = VnPayHelper.CreatePaymentUrl(model, _config, ipAddress);

            return Ok(new PaymentResponseDTO
            {
                PaymentUrl = url,
                Message = "Tạo thanh toán thành công, vui lòng quét mã QR hoặc nhấn vào link."
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

            // Trả về đúng format cho VNPAY: responseCode=00
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
}
