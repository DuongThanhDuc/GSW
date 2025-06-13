using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class GamesCategoryDTO
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public int CategoryID { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string? GameName { get; set; }
        public string? CategoryName { get; set; }
    }

    public class CreateGamesCategoryDTO
    {
        public int GameID { get; set; }
        public int CategoryID { get; set; }
        public string CreatedBy { get; set; }
    }

    public class UpdateGamesCategoryDTO
    {
        public int GameID { get; set; }
        public int CategoryID { get; set; }
        public string CreatedBy { get; set; }
    }
}
