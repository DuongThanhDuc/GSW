using BusinessModel.Migrations;
using BusinessModel.Model;
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
            // Tìm order theo OrderCode (trùng với OrderId bên PaymentTransaction)
            var order = await _context.Store_Orders.FirstOrDefaultAsync(o => o.OrderCode == orderCode);
            if (order == null) return;

            var orderDbId = order.ID;
            var userId = order.UserID;

            // Lấy danh sách game trong đơn hàng
            var gameIds = await _context.Store_OrderDetails
                .Where(od => od.OrderID == orderDbId)
                .Select(od => od.GameID)
                .ToListAsync();

            // Lấy các game đã có trong Store_Library của user
            var existingGameIds = await _context.Store_Library
                .Where(lib => lib.UserID == userId)
                .Select(lib => lib.GamesID)
                .ToListAsync();

            foreach (var gameId in gameIds)
            {
                if (!existingGameIds.Contains(gameId))
                {
                    _context.Store_Library.Add(new BusinessModel.Model.StoreLibrary
                    {
                        UserID = userId,
                        GamesID = gameId,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }
            await _context.SaveChangesAsync();
        }

    }
}
