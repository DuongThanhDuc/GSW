using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class PaymentTransaction
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // "VNPAY"
        public string Status { get; set; } // "Pending", "Success", "Failed"
        public DateTime CreatedAt { get; set; }
        public string? PaymentGatewayResponse { get; set; }
    }  
}
