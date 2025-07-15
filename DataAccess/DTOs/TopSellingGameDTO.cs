using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class TopSellingGameDTO
    {
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        public string Genre { get; set; }
        public string DeveloperId { get; set; }
        public string Status { get; set; }
        public int SoldQuantity { get; set; }
        public decimal TotalRevenue { get; set; }
    }
    public class TopSellingGamePagingDTO
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int Page { get; set; }
        public List<TopSellingGameDTO> Games { get; set; }
    }
}
