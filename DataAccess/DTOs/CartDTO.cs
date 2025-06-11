using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class CartDTO
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int GameID { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
