﻿using BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class StoreLibraryDTO
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int GamesID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
