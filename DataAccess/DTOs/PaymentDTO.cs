using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class PaymentRequestDTO
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }

    }

    public class PaymentResponseDTO
    {
        public string PaymentUrl { get; set; }
        public string Message { get; set; }
        public string OrderId { get; set; }
    }

    public class VnPayCallbackDTO
    {
        public string vnp_TxnRef { get; set; }
        public string vnp_Amount { get; set; }
        public string vnp_ResponseCode { get; set; }
    }

}
