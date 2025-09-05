using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class GamesReview
    {
        public int ID { get; set; }

        [Required]
        public int GameID { get; set; }

        [ForeignKey("GameID")]
        public GamesInfo Game { get; set; }

        [StringLength(50)]  
        public string UserID { get; set; }

        public bool IsUpvoted { get; set; }

        [StringLength(512)]  
        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
