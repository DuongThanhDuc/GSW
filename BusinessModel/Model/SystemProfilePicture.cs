using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class SystemProfilePicture
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]  
        public string UserId { get; set; }

        [Required]
        [StringLength(512)]  
        public string ImageUrl { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }
    }

}
