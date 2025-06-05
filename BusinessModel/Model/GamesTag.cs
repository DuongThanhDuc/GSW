using System;
using System.Collections.Generic;
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
        public SystemTag Tag { get; set; } // Corrected from SystemCategory

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string CreatedBy { get; set; }
    }
}
