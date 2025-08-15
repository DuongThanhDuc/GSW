using BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class StoreThreadReplyUpvoteHistoryDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ThreadCommentId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class StoreThreadReplyUpvoteHistoryDTOReadOnly
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int ThreadCommentId { get; set; }
        public string ThreadComment { get; set; }
        public string commentUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
