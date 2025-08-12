using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class GamesReviewDTO
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public string UserID { get; set; }
        public bool IsUpvoted { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class GamesReviewDTOReadOnly
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
        public bool IsUpvoted { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

