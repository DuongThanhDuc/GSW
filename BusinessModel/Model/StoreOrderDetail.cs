using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class StoreOrderDetail
    {
        public int ID { get; set; }

        public int OrderID { get; set; }
        public StoreOrder Order { get; set; }

        public int GameID { get; set; }
        public GamesInfo Game { get; set; }

        public decimal UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
