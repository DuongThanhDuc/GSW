using BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class StoreWishlistDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int WishlistGameId { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
