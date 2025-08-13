using BusinessModel.Migrations;
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

        public async Task<PaymentTransaction> CreateTransactionAsync(PaymentTransaction transaction)
        {
            _context.PaymentTransactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<PaymentTransaction> GetByOrderIdAsync(string orderId)
        {
            return await _context.PaymentTransactions.FirstOrDefaultAsync(x => x.OrderId == orderId);
        }

        public async Task UpdateTransactionAsync(PaymentTransaction transaction)
        {
            _context.PaymentTransactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task GrantGameToLibraryAsync(string orderCode)
        {
            // Find order by OrderCode
            var order = await _context.Set<StoreOrderDTO>()
                .FirstOrDefaultAsync(o => o.OrderId == orderCode);

            if (order == null)
                return;

            var orderDbId = order.ID;
            var userId = order.UserID;

            // Get list of game IDs from the order
            var gameIds = await _context.Set<StoreOrderDetailDTO>()
                .Where(od => od.OrderID == orderDbId)
                .Select(od => od.GameID)
                .ToListAsync();

            // Get list of existing game IDs in user's library
            var existingGameIds = await _context.Set<StoreLibraryDTO>()
                .Where(lib => lib.UserID == userId)
                .Select(lib => lib.GamesID)
                .ToListAsync();

            // Add games that aren't already in the library
            foreach (var gameId in gameIds)
            {
                if (!existingGameIds.Contains(gameId))
                {
                    _context.Set<StoreLibraryDTO>().Add(new StoreLibraryDTO
                    {
                        UserID = userId,
                        GamesID = gameId,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            await _context.SaveChangesAsync();
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
