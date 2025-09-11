using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class PaymentTransaction
    {
        public int Id { get; set; }

        // FK CHUẨN về StoreOrder
        public int StoreOrderId { get; set; }
        public StoreOrder StoreOrder { get; set; }

        // Mã tham chiếu của cổng (VD: vnp_TxnRef)
        public string? GatewayOrderId { get; set; }

        public decimal Amount { get; set; }
        [MaxLength(20)]
        public string PaymentMethod { get; set; }   // "VNPAY", "MOMO"
        [MaxLength(20)]
        public string Status { get; set; }          // "Pending", "Success", "Failed"
        public DateTime CreatedAt { get; set; }
        public string? PaymentGatewayResponse { get; set; }
    }


}
