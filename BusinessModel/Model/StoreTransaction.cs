using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class StoreTransaction
    {
        public int ID { get; set; }

        public int OrderID { get; set; }
        public StoreOrder Order { get; set; }

        public int? PaymentTransactionId { get; set; }
        public PaymentTransaction? PaymentTransaction { get; set; }

        public string PaymentMethod { get; set; }
        public string Status { get; set; } = "PENDING";
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public ICollection<PaymentTransaction> PaymentTransactions { get; set; }

    }
}
