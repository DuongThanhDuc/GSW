using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class StoreOrder
    {
        public int ID { get; set; }

        [StringLength(50)] 
        public string? UserID { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Range(0.01, 999999999)]  
        public decimal TotalAmount { get; set; }

        [StringLength(20)]  
        public string Status { get; set; } = "PENDING";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required, MaxLength(64)]  
        public string OrderCode { get; set; }

        [MaxLength(256)]
        [EmailAddress]  
        public string? BuyerEmail { get; set; }

        [MaxLength(128)]  
        public string? BuyerName { get; set; }

        public ICollection<StoreOrderDetail> OrderDetails { get; set; }
        public ICollection<StoreTransaction> Transactions { get; set; }
        public ICollection<StoreRefundRequest> RefundRequests { get; set; }
        public ICollection<PaymentTransaction> PaymentTransactions { get; set; }
    }

}
