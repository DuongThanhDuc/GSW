using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class SystemProfilePicture
    {
        public int Id { get; set; }
        [MaxLength(450)]
        public string UserId { get; set; }
        public string ImageUrl { get; set; }
        public IdentityUser User { get; set; }
    }
}
