using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class GamesTag
    {
        public int ID { get; set; }

        [Required]
        public int GameID { get; set; }

        [ForeignKey("GameID")]
        public GamesInfo Game { get; set; }

        [Required]
        public int TagID { get; set; }

        [ForeignKey("TagID")]
        public SystemTag Tag { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [StringLength(50)]  
        public string CreatedBy { get; set; }
    }

}
