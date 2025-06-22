using BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class GamesDatabaseDTO
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string GameFilePathURL { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
