using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class RevenueStatisticDTO
    {
        public decimal TotalRevenue { get; set; }
        public int TotalOrders { get; set; }
        public int TotalRefunds { get; set; }
        public int TotalUsersPurchased { get; set; }
        public List<RevenueByDayDTO> RevenueByDay { get; set; }
        public List<GameRevenueDTO> GameRevenues { get; set; }
        public List<GameRevenueDTO> TopSellingGames { get; set; }
    }
    public class RevenueByDayDTO
    {
        public DateTime Date { get; set; }
        public decimal Revenue { get; set; }
        public int Orders { get; set; }
    }

    public class GameRevenueDTO
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public int SoldQuantity { get; set; }
        public decimal Revenue { get; set; }
    }
}
