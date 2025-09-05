using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class StoreThreadReply
    {
        public int Id { get; set; }

        [Required]
        public int ThreadID { get; set; }

        [ForeignKey("ThreadID")]
        public StoreThread StoreThread { get; set; }

        [Required]
        [StringLength(512)]  
        public string ThreadComment { get; set; }

        [StringLength(512)]  
        public string? CommentImageUrl { get; set; }

        public int UpvoteCount { get; set; }

        [Required]
        [StringLength(50)]  
        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
