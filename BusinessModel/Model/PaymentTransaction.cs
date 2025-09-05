using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class PaymentTransaction
    {
        public int Id { get; set; }

        [Required]
        public int StoreOrderId { get; set; }

        [ForeignKey("StoreOrderId")]
        public StoreOrder StoreOrder { get; set; }

        [StringLength(50)]  
        public string? GatewayOrderId { get; set; }

        [Required]
        [Range(0.01, 999999999)]  
        public decimal Amount { get; set; }

        [StringLength(50)] 
        public string PaymentMethod { get; set; }   // "VNPAY"

        [StringLength(20)]  
        public string Status { get; set; }          // "Pending", "Success", "Failed"

        public DateTime CreatedAt { get; set; }

        [StringLength(512)]  
        public string? PaymentGatewayResponse { get; set; }
    }

}
