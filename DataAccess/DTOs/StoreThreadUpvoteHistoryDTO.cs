using BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class StoreThreadUpvoteHistoryDTO
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public int ThreadID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class StoreThreadUpvoteHistoryDTOReadOnly
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int ThreadID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
