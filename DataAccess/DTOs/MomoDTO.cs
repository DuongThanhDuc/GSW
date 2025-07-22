namespace DataAccess.DTOs
{
    public class MomoPaymentRequestDTO
    {
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
    }

    public class MomoPaymentResponseDTO
    {
        public int errorCode { get; set; }
        public string payUrl { get; set; }
        public string message { get; set; }
        public string orderId { get; set; }
        public string requestId { get; set; }
    }

    public class MomoNotifyDTO
    {
        public string partnerCode { get; set; }
        public string accessKey { get; set; }
        public string requestId { get; set; }
        public string amount { get; set; }
        public string orderId { get; set; }
        public string orderInfo { get; set; }
        public string orderType { get; set; }
        public string transId { get; set; }
        public int resultCode { get; set; }
        public string message { get; set; }
        public string payType { get; set; }
        public string responseTime { get; set; }
        public string extraData { get; set; }
        public string signature { get; set; }
    }
}
