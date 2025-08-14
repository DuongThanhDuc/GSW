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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DBContext _context;
        public PaymentRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<PaymentTransaction?> GetByOrderCodeAsync(string orderCode)
        {
            var order = await _context.Store_Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.OrderCode == orderCode);
            if (order == null) return null;

            return await _context.PaymentTransactions
                .Where(p => p.StoreOrderId == order.ID)
                .OrderByDescending(p => p.CreatedAt)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PaymentTransaction>> GetByStoreOrderIdAsync(int storeOrderId)
        {
            return await _context.PaymentTransactions
                .Where(p => p.StoreOrderId == storeOrderId)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<StoreOrder?> FindOrderByCodeAsync(string orderCode)
        {
            return await _context.Store_Orders.FirstOrDefaultAsync(o => o.OrderCode == orderCode);
        }

        public async Task<PaymentTransaction> CreateTransactionAsync(PaymentTransaction tx)
        {
            _context.PaymentTransactions.Add(tx);
            await _context.SaveChangesAsync();
            return tx;
        }

        public async Task<StoreOrder> CreateProvisionalOrderAsync(
    string orderCode, string? userId, decimal amount,
    string? buyerEmail = null, string? buyerName = null)
        {
            var exist = await _context.Store_Orders
                .FirstOrDefaultAsync(o => o.OrderCode == orderCode);
            if (exist != null)
            {
                // Nếu đơn đã tồn tại mà thiếu thông tin người mua, có thể cập nhật bù
                if (string.IsNullOrEmpty(exist.BuyerEmail) && !string.IsNullOrEmpty(buyerEmail))
                    exist.BuyerEmail = buyerEmail;
                if (string.IsNullOrEmpty(exist.BuyerName) && !string.IsNullOrEmpty(buyerName))
                    exist.BuyerName = buyerName;

                await _context.SaveChangesAsync();
                return exist;
            }

            var order = new StoreOrder
            {
                UserID = userId,                 // null nếu guest
                OrderCode = orderCode,
                OrderDate = DateTime.Now,
                CreatedAt = DateTime.Now,
                TotalAmount = amount,
                Status = "PENDING",
                BuyerEmail = buyerEmail,
                BuyerName = buyerName,
                OrderDetails = new List<StoreOrderDetail>()
            };

            _context.Store_Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }


        public async Task UpdateTransactionAsync(PaymentTransaction transaction)
        {
            _context.PaymentTransactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task GrantGameToLibraryAsync(string orderCode)
        {
            var orderDto = await _context.Store_Orders
                .Where(o => o.OrderCode == orderCode)
                .Select(o => new StoreOrderDTO
                {
                    ID = o.ID,
                    UserID = o.UserID,
                    OrderId = o.OrderCode,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status,
                    CreatedAt = o.CreatedAt
                })
                .FirstOrDefaultAsync();

            if (orderDto == null)
            {
                Console.WriteLine($"[GrantLibrary] Order not found: {orderCode}");
                return;
            }

            if (string.IsNullOrEmpty(orderDto.UserID))
            {
                Console.WriteLine($"[GrantLibrary] Order {orderCode} has no UserID, skipping.");
                return; // or handle guest library
            }

            var gameIds = await _context.Store_OrderDetails
                .Where(od => od.OrderID == orderDto.ID)
                .Select(od => od.GameID)
                .ToListAsync();

            Console.WriteLine($"[GrantLibrary] Found {gameIds.Count} games for order {orderCode}");

            if (!gameIds.Any()) return;

            var existingGameIds = await _context.Store_Library
                .Where(lib => lib.UserID == orderDto.UserID)
                .Select(lib => lib.GamesID)
                .ToListAsync();

            foreach (var gameId in gameIds)
            {
                if (!existingGameIds.Contains(gameId))
                {
                    _context.Store_Library.Add(new StoreLibrary
                    {
                        UserID = orderDto.UserID,
                        GamesID = gameId,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            await _context.SaveChangesAsync();
            Console.WriteLine($"[GrantLibrary] Added games to library for user {orderDto.UserID}");
        }






        public async Task UpdateOrderStatusByCodeAsync(string orderCode, string status)
        {
            var order = await _context.Store_Orders
                .FirstOrDefaultAsync(o => o.OrderCode == orderCode);
            if (order == null) return;

            order.Status = status; 
            await _context.SaveChangesAsync();
        }

    }
}
