using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class StoreWishlist
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int GameId { get; set; }
        public GamesInfo GamesInfo { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
