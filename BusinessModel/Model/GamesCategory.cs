using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class GamesCategory
    {
        public int ID { get; set; }

        public int GameID { get; set; }
        public GamesInfo Game { get; set; }

        public int CategoryID { get; set; }
        public SystemCategory Category { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string CreatedBy { get; set; }
    }
}
