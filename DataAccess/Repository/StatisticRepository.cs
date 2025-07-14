using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly DBContext _context;

        public StatisticRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<RevenueStatisticDTO> GetRevenueStatisticAsync(RevenueStatisticRequestDTO req)
        {
            // 1. Lọc Order theo ngày, user, status
            var ordersQuery = _context.Store_Orders
                .Where(o => o.OrderDate >= req.From && o.OrderDate <= req.To);

            if (!string.IsNullOrEmpty(req.UserId))
                ordersQuery = ordersQuery.Where(o => o.UserID == req.UserId);

            if (!string.IsNullOrEmpty(req.OrderStatus))
                ordersQuery = ordersQuery.Where(o => o.Status == req.OrderStatus);

            var orders = await ordersQuery.ToListAsync();
            var orderIds = orders.Select(o => o.ID).ToList();

            // 2. Lọc OrderDetail theo OrderID, GameID
            var orderDetailsQuery = _context.Store_OrderDetails
                .Where(d => orderIds.Contains(d.OrderID));
            if (req.GameId.HasValue)
                orderDetailsQuery = orderDetailsQuery.Where(d => d.GameID == req.GameId.Value);

            var orderDetails = await orderDetailsQuery.ToListAsync();

            // 3. Tính tổng doanh thu
            decimal totalRevenue = orderDetails.Sum(d => d.UnitPrice);

            // 4. Thống kê theo ngày
            var revenueByDay = orders
                .GroupBy(o => o.OrderDate.Date)
                .Select(g => new RevenueByDayDTO
                {
                    Date = g.Key,
                    Revenue = orderDetails
                        .Where(d => g.Select(x => x.ID).Contains(d.OrderID))
                        .Sum(d => d.UnitPrice),
                    Orders = g.Count()
                }).ToList();

            // 5. Đếm refund: RefundRequest liên kết OrderID (KHÔNG phải OrderDetailId)
            int totalRefunds = await _context.Store_RefundRequests
                .Where(r => orderIds.Contains(r.OrderID) && r.Status == "APPROVED")
                .CountAsync();

            // 6. Đếm user mua hàng
            int totalUsersPurchased = orders.Select(o => o.UserID).Distinct().Count();

            // 7. Doanh thu từng game
            var gameIds = orderDetails.Select(d => d.GameID).Distinct().ToList();
            var games = await _context.Games_Info.Where(g => gameIds.Contains(g.Id)).ToListAsync();

            var gameRevenues = orderDetails
                .GroupBy(d => d.GameID)
                .Select(g => new GameRevenueDTO
                {
                    GameId = g.Key,
                    GameName = games.FirstOrDefault(x => x.Id == g.Key)?.Title,  // SỬA lại dùng Title
                    SoldQuantity = g.Count(),
                    Revenue = g.Sum(x => x.UnitPrice)
                }).ToList();

            // 8. Top N game bán chạy
            var topSellingGames = gameRevenues
                .OrderByDescending(g => g.SoldQuantity)
                .Take(req.TopNGame ?? 5)
                .ToList();

            return new RevenueStatisticDTO
            {
                TotalRevenue = totalRevenue,
                TotalOrders = orders.Count,
                TotalRefunds = totalRefunds,
                TotalUsersPurchased = totalUsersPurchased,
                RevenueByDay = revenueByDay,
                GameRevenues = gameRevenues,
                TopSellingGames = topSellingGames
            };
        }

    }
}
