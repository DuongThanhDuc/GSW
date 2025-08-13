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
            // Lấy đơn + chi tiết
            var order = await _context.Store_Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.OrderCode == orderCode);
            if (order == null) return;

            // Nếu là guest (chưa có UserID) thì chưa cấp – chờ user claim sau
            if (string.IsNullOrEmpty(order.UserID)) return;

            var userId = order.UserID;

            // Lấy danh sách game trong đơn
            var gameIds = order.OrderDetails?
                .Select(d => d.GameID)
                .Distinct()
                .ToList() ?? new List<int>();
            if (gameIds.Count == 0) return;

            // Tránh cấp trùng – lấy các game đã có trong Library
            var existingGameIds = await _context.Store_Library
                .Where(l => l.UserID == userId && gameIds.Contains(l.GamesID))
                .Select(l => l.GamesID)
                .ToListAsync();

            var toAdd = gameIds.Except(existingGameIds);
            foreach (var gameId in toAdd)
            {
                _context.Store_Library.Add(new BusinessModel.Model.StoreLibrary
                {
                    UserID = userId,
                    GamesID = gameId,
                    CreatedAt = DateTime.Now
                });
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
