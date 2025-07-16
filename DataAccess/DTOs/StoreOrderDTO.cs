using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class StoreOrderDTO
    {
        public int ID { get; set; }

        public string UserID { get; set; }

        public DateTime OrderDate { get; set; } 
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "COMPLETED";
        public DateTime CreatedAt { get; set; } 
    }

    public class StoreOrderDTOReadOnly
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public List<StoreOrderDetailDTOReadOnly> OrderDetails { get; set; }
    }
}
