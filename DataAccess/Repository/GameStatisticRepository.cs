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
    public class GameStatisticRepository : IGameStatisticRepository
    {
        private readonly DBContext _context;

        public GameStatisticRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<List<TopSellingGameDTO>> GetTopSellingGamesAsync(DateTime from, DateTime to, int topN)
        {
            // Lọc order hoàn tất trong khoảng thời gian
            var orders = await _context.Store_Orders
                .Where(o => o.OrderDate >= from && o.OrderDate <= to && o.Status == "COMPLETED")
                .Select(o => o.ID)
                .ToListAsync();

            // Lấy chi tiết đơn hàng
            var orderDetails = await _context.Store_OrderDetails
                .Where(od => orders.Contains(od.OrderID))
                .ToListAsync();

            // Nhóm theo game
            var gameIds = orderDetails.Select(od => od.GameID).Distinct().ToList();
            var games = await _context.Games_Info.Where(g => gameIds.Contains(g.Id)).ToListAsync();

            var topGames = orderDetails
                .GroupBy(od => od.GameID)
                .Select(g => new TopSellingGameDTO
                {
                    GameId = g.Key,
                    GameTitle = games.FirstOrDefault(x => x.Id == g.Key)?.Title ?? "Unknown",
                    SoldQuantity = g.Count(),
                    TotalRevenue = g.Sum(x => x.UnitPrice)
                })
                .OrderByDescending(g => g.SoldQuantity)
                .Take(topN)
                .ToList();

            return topGames;
        }
        public async Task<TopSellingGamePagingDTO> GetTopSellingGamesAsync(TopSellingGameRequestDTO req)
        {
            var orders = await _context.Store_Orders
                .Where(o => o.OrderDate >= req.From && o.OrderDate <= req.To && o.Status == "COMPLETED")
                .Select(o => o.ID)
                .ToListAsync();

            var orderDetails = await _context.Store_OrderDetails
                .Where(od => orders.Contains(od.OrderID))
                .ToListAsync();

            var gamesQuery = _context.Games_Info.AsQueryable();

            // Filter theo Genre
            if (!string.IsNullOrEmpty(req.Genre))
                gamesQuery = gamesQuery.Where(g => g.Genre == req.Genre);

            // Filter theo Developer
            if (!string.IsNullOrEmpty(req.DeveloperId))
                gamesQuery = gamesQuery.Where(g => g.DeveloperId == req.DeveloperId);

            // Filter theo trạng thái
            if (!string.IsNullOrEmpty(req.Status))
                gamesQuery = gamesQuery.Where(g => g.Status == req.Status);

            var games = await gamesQuery.ToListAsync();

            // Join orderDetails với games (theo GameID)
            var query =
                from od in orderDetails
                join g in games on od.GameID equals g.Id
                group new { od, g } by new { od.GameID, g.Title, g.Genre, g.DeveloperId, g.Status } into grp
                select new TopSellingGameDTO
                {
                    GameId = grp.Key.GameID,
                    GameTitle = grp.Key.Title,
                    Genre = grp.Key.Genre,
                    DeveloperId = grp.Key.DeveloperId,
                    Status = grp.Key.Status,
                    SoldQuantity = grp.Count(),
                    TotalRevenue = grp.Sum(x => x.od.UnitPrice)
                };

            var topGames = query.OrderByDescending(g => g.SoldQuantity).ToList();
            int totalRecords = topGames.Count();

            // Áp dụng TopN và phân trang trên List:
            if (req.TopN > 0)
                topGames = topGames.Take(req.TopN).ToList();

            int page = req.Page < 1 ? 1 : req.Page;
            int pageSize = req.PageSize < 1 ? 10 : req.PageSize;

            var paged = topGames
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();


            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            return new TopSellingGamePagingDTO
            {
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                Page = page,
                Games = paged
            };
        }

    }
}
