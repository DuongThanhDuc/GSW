using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class StoreThread
    {
        public int Id { get; set; } 
        public string ThreadTitle { get; set; }
        public string ThreadDescription { get; set; }  
        public string? ThreadImageUrl { get; set; }
        public int UpvoteCount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<StoreThreadReply> Replies { get; set; }

    }
}
