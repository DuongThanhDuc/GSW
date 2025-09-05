using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class GameDatabase
    {
        public int Id { get; set; }

        [Required]
        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public GamesInfo Game { get; set; }

        [StringLength(512)]  
        public string GameFilePathURL { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
