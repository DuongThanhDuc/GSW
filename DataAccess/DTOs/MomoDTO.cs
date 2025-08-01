namespace DataAccess.DTOs
{
    // Tạo Payment
    public class MomoPaymentRequestDTO
    {
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
    }

    // Kết quả tạo Payment (API /v2/gateway/api/create trả về)
    public class MomoPaymentResponseDTO
    {
        public string partnerCode { get; set; }
        public string requestId { get; set; }
        public string orderId { get; set; }
        public long amount { get; set; }
        public long responseTime { get; set; }
        public string message { get; set; }
        public int resultCode { get; set; }
        public string payUrl { get; set; }
        public string deeplink { get; set; }
        public string qrCodeUrl { get; set; }
        public string signature { get; set; }
    }

    // DTO IPN từ MOMO (NotifyUrl gửi đến backend)
    public class MomoIPNRequestDTO
    {
        public string partnerCode { get; set; }
        public string orderId { get; set; }
        public string requestId { get; set; }
        public long amount { get; set; }
        public string orderInfo { get; set; }
        public string orderType { get; set; }
        public string transId { get; set; }
        public int resultCode { get; set; }
        public string message { get; set; }
        public string payType { get; set; }
        public long responseTime { get; set; }
        public string extraData { get; set; } = ""; 
        public string signature { get; set; }
    }


    // Callback user redirect sau khi thanh toán (MoMo V3)
    public class MomoCallbackDTO
    {
        public string partnerCode { get; set; }
        public string orderId { get; set; }
        public string requestId { get; set; }
        public long amount { get; set; }
        public string orderInfo { get; set; }
        public string orderType { get; set; }
        public string transId { get; set; }
        public int resultCode { get; set; }     
        public string message { get; set; }
        public string payType { get; set; }
        public long responseTime { get; set; }
        public string extraData { get; set; }
        public string signature { get; set; }
    }

}
