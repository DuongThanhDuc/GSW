﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class SystemMedia
    {
        public int Id { get; set; } 
        public string MediaURL { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
