using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(450)]
        public string UserID { get; set; }
        [MaxLength(512)]
        public string Reason { get; set; }
        [MaxLength(20)]
        public string Status { get; set; } = "PENDING";
        public DateTime RequestDate { get; set; } = DateTime.Now;
    }
}
