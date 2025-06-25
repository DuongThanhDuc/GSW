using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class GamesMedia
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public GamesInfo Game { get; set; }
        public string MediaURL { get; set; }   
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
