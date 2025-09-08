using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class GamesTag
    {
        public int ID { get; set; }

        public int GameID { get; set; }
        public GamesInfo Game { get; set; }

        public int TagID { get; set; }
        public SystemTag Tag { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [MaxLength(450)]
        public string CreatedBy { get; set; }
    }
}
