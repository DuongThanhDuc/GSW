using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class StoreThreadReplyUpvoteHistory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]  
        public string UserId { get; set; }

        [Required]
        public int ThreadCommentId { get; set; }

        [ForeignKey("ThreadCommentId")]
        public StoreThreadReply ThreadReply { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
