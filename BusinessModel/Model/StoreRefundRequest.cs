using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class StoreRefundRequest
    {
        public int ID { get; set; }

        public int OrderID { get; set; }
        public StoreOrder Order { get; set; }

        public string UserID { get; set; }

        public string Reason { get; set; }
        public string Status { get; set; } = "PENDING";
        public DateTime RequestDate { get; set; } = DateTime.Now;
    }
}
