using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class RevenueStatisticRequestDTO
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int? GameId { get; set; }
        public string UserId { get; set; }
        public string OrderStatus { get; set; }
        public int? TopNGame { get; set; }
    }
}
