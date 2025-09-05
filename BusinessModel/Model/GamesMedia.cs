using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class GamesMedia
    {
        public int Id { get; set; }

        [Required]
        public int GameID { get; set; }

        [ForeignKey("GameID")]
        public GamesInfo Game { get; set; }

        [StringLength(512)]  
        public string MediaURL { get; set; }

        [StringLength(50)]  
        public string MediaType { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
