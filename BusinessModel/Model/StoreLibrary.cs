using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class StoreLibrary
    {
        public int ID { get; set; }
        [MaxLength(450)]
        public string UserID { get; set; }
        public int GamesID { get; set; }
        public GamesInfo Game { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
