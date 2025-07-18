﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class GamesReview
    {
        public int ID { get; set; }

        public int GameID { get; set; }
        public GamesInfo Game { get; set; }

        public string UserID { get; set; }

        public int StarCount { get; set; }
        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
