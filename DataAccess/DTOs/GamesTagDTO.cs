using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class GamesTagDTO
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public int TagID { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string? GameName { get; set; }
        public string? TagName { get; set; }
    }

    public class CreateGamesTagDTO
    {
        public int GameID { get; set; }
        public int TagID { get; set; }
        public string CreatedBy { get; set; }
    }

    public class UpdateGamesTagDTO
    {
        public int GameID { get; set; }
        public int TagID { get; set; }
        public string CreatedBy { get; set; }
    }
}
