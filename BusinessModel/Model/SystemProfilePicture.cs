﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class SystemProfilePicture
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ImageUrl { get; set; }
        public IdentityUser User { get; set; }
    }
}
