using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs 
{ 
    // DTO gửi yêu cầu tạo thanh toán
    public class PaymentRequestDTO
    {
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // "VNPAY"
    }

    // DTO trả về link thanh toán
    public class PaymentResponseDTO
    {
        public string PaymentUrl { get; set; }
        public string Message { get; set; }
    }

    // DTO nhận callback từ VNPAY
    public class VnPayCallbackDTO
    {
        public string vnp_TxnRef { get; set; }         // Mã đơn hàng
        public string vnp_ResponseCode { get; set; }   // Mã kết quả giao dịch
        public string vnp_TransactionNo { get; set; }  // Mã giao dịch tại VNPAY
        public string vnp_SecureHash { get; set; }     // Chữ ký bảo mật

    }
}
