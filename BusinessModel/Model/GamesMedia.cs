using System;
using System.Collections.Generic;
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
        public int GameID { get; set; }
        public GamesInfo Game { get; set; }
        public string MediaURL { get; set; }
        [MaxLength(25)]
        public string MediaType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
