using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class StoreThreadReply
    {
        public int Id { get; set; } 
        public int ThreadID { get; set; }
        public StoreThread StoreThread { get; set; }
        public string ThreadComment { get; set; }
        public string? CommentImageUrl {  get; set; }    
        public int UpvoteCount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
