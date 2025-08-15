using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
                bool changed = false;

                if (string.IsNullOrEmpty(exist.BuyerEmail) && !string.IsNullOrEmpty(buyerEmail))
                {
                    exist.BuyerEmail = buyerEmail;
                    changed = true;
                }
                if (string.IsNullOrEmpty(exist.BuyerName) && !string.IsNullOrEmpty(buyerName))
                {
                    exist.BuyerName = buyerName;
                    changed = true;
                }

                if (changed)
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
                Status = "Pending",              
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
            Console.WriteLine($"[GrantLibrary] Processing order {orderCode}...");

            // 1. Get order info
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

            if (string.IsNullOrWhiteSpace(orderDto.UserID))
            {
                Console.WriteLine($"[GrantLibrary] Order {orderCode} has no UserID — skipping (guest order?)");
                return;
            }

            // 2. Get all game IDs in this order
            var gameIds = await _context.Store_OrderDetails
                .Where(od => od.OrderID == orderDto.ID)
                .Select(od => od.GameID)
                .Distinct()
                .ToListAsync();

            Console.WriteLine($"[GrantLibrary] Found {gameIds.Count} games for order {orderCode}");

            if (!gameIds.Any())
            {
                Console.WriteLine($"[GrantLibrary] No games found for order {orderCode}");
                return;
            }

            // 3. Get user's current library
            var existingGameIds = await _context.Store_Library
                .Where(lib => lib.UserID == orderDto.UserID)
                .Select(lib => lib.GamesID)
                .ToListAsync();

            int addedCount = 0;

            // 4. Add missing games to library
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
                    addedCount++;
                    Console.WriteLine($"[GrantLibrary] Added game {gameId} to library");
                }
                else
                {
                    Console.WriteLine($"[GrantLibrary] Game {gameId} already in library — skipping");
                }
            }

            // 5. Commit changes
            if (addedCount > 0)
            {
                await _context.SaveChangesAsync();
                Console.WriteLine($"[GrantLibrary] Added {addedCount} games to user {orderDto.UserID}'s library");
            }
            else
            {
                Console.WriteLine($"[GrantLibrary] No new games to add for order {orderCode}");
            }
        }



        public async Task UpdateOrderStatusByCodeAsync(string orderCode, string status)
        {
            var order = await _context.Store_Orders
                .FirstOrDefaultAsync(o => o.OrderCode == orderCode);
            if (order == null) return;

            // Chuẩn hoá casing để nhất quán với Controller
            string normalized = status?.Trim().ToLowerInvariant() switch
            {
                "success" => "Success",
                "failed" => "Failed",
                _ => "Pending"
            };

            if (!string.Equals(order.Status, normalized, StringComparison.Ordinal))
            {
                order.Status = normalized;              
                await _context.SaveChangesAsync();
            }
        }
    }
}
