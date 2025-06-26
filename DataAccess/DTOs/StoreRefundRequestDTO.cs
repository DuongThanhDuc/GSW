using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class StoreRefundRequestDTO
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public string UserID { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
