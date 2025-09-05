using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class StoreOrderDetail
    {
        public int ID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [ForeignKey("OrderID")]
        public StoreOrder Order { get; set; }

        [Required]
        public int GameID { get; set; }

        [ForeignKey("GameID")]
        public GamesInfo Game { get; set; }

        [Range(0.01, 999999999)]
        public decimal UnitPrice { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
