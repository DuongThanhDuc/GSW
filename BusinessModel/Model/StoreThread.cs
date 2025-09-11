using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class StoreThread
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string ThreadTitle { get; set; }
        [MaxLength(250)]
        public string ThreadDescription { get; set; }  
        public string? ThreadImageUrl { get; set; }
        public int UpvoteCount { get; set; }
        [MaxLength(450)]
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<StoreThreadReply> Replies { get; set; }

    }
}
