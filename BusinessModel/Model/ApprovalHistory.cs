using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class ApprovalHistory
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]  
        public string EntityType { get; set; }

        public int EntityId { get; set; }

        [StringLength(50)]  
        public string Status { get; set; }

        [Required]
        [StringLength(50)]
        public string ChangedByUserId { get; set; }

        public DateTime ChangedAt { get; set; }

        [StringLength(512)]
        public string Note { get; set; }

        [ForeignKey("ChangedByUserId")]
        public IdentityUser ChangedByUser { get; set; }
    }

}
