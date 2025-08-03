using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class StoreThreadReplyUpvoteHistory
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ThreadCommentId { get; set; }
        public StoreThreadReply ThreadReply { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        p
    }
}
