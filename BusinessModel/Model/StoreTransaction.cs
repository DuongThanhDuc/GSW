using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class StoreTransaction
    {
        public int ID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [ForeignKey("OrderID")]
        public StoreOrder Order { get; set; }

        public int? PaymentTransactionId { get; set; }

        [ForeignKey("PaymentTransactionId")]
        public PaymentTransaction? PaymentTransaction { get; set; }

        [Required]
        [StringLength(50)]  
        public string PaymentMethod { get; set; }

        [StringLength(20)]  
        public string Status { get; set; } = "PENDING";

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public ICollection<PaymentTransaction> PaymentTransactions { get; set; }
    }

}
