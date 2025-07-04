﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class StoreOrderDTO
    {
        public int ID { get; set; }

        public string UserID { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "COMPLETED";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
