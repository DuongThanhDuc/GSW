using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class StoreCart
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]  
        public string UserID { get; set; }

        [Required]
        public int GameID { get; set; }

        [ForeignKey("GameID")]
        public GamesInfo Game { get; set; }

        public DateTime AddedAt { get; set; } = DateTime.Now;
    }

}
