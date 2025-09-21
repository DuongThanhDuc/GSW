using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{

    public class OrderMinDTO
    {
        public int Id { get; set; }
        public string? OrderCode { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class UserMinDTO
    {
        public string Id { get; set; } = default!;
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        
    }
    public class StoreRefundRequestDTO
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public string UserID { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public DateTime RequestDate { get; set; }

        //public OrderMinDTO Order { get; set; }
        //public UserMinDTO User { get; set; } 
    }
}
