using BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class StoreThreadReplyDTO
    {
        public int Id { get; set; }
        public int ThreadID { get; set; }
        public string ThreadComment { get; set; }
        public int UpvoteCount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
