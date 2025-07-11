﻿using BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class StoreThreadDTO
    {
        public int Id { get; set; }
        public string ThreadTitle { get; set; }
        public string ThreadDescription { get; set; }
        public int UpvoteCount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
