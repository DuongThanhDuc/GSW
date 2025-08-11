using BusinessModel.Model;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly DBContext _ctx;
        public WalletRepository(DBContext ctx) => _ctx = ctx;

        public async Task<UserWallet> GetOrCreateAsync(string userId, CancellationToken ct = default)
        {
            var w = await _ctx.User_Wallets.FirstOrDefaultAsync(x => x.UserId == userId, ct);
            if (w == null)
            {
                w = new UserWallet { UserId = userId, Balance = 0m, UpdatedAt = DateTime.Now };
                _ctx.User_Wallets.Add(w);
                await _ctx.SaveChangesAsync(ct);
            }
            return w;
        }

        public async Task IncreaseAsync(string userId, decimal amount, CancellationToken ct = default)
        {
            // Atomic: UPDATE balance = balance + amount
            var rows = await _ctx.User_Wallets
                .Where(w => w.UserId == userId)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(w => w.Balance, w => w.Balance + amount)
                    .SetProperty(w => w.UpdatedAt, _ => DateTime.Now), ct);

            if (rows == 0)
            {
                // Nếu chưa có ví (rare), tạo rồi cộng lại
                await GetOrCreateAsync(userId, ct);
                await _ctx.User_Wallets
                    .Where(w => w.UserId == userId)
                    .ExecuteUpdateAsync(s => s
                        .SetProperty(w => w.Balance, w => w.Balance + amount)
                        .SetProperty(w => w.UpdatedAt, _ => DateTime.Now), ct);
            }
        }

        public async Task<bool> DecreaseIfEnoughAsync(string userId, decimal amount, CancellationToken ct = default)
        {
            // Atomic: chỉ trừ khi đủ số dư
            var rows = await _ctx.User_Wallets
                .Where(w => w.UserId == userId && w.Balance >= amount)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(w => w.Balance, w => w.Balance - amount)
                    .SetProperty(w => w.UpdatedAt, _ => DateTime.Now), ct);

            if (rows == 0)
            {
                // đảm bảo có ví (nếu chưa)
                await GetOrCreateAsync(userId, ct);
                // thử lại 1 lần (trong trường hợp vừa tạo ví thì chắc chắn không đủ)
                rows = await _ctx.User_Wallets
                    .Where(w => w.UserId == userId && w.Balance >= amount)
                    .ExecuteUpdateAsync(s => s
                        .SetProperty(w => w.Balance, w => w.Balance - amount)
                        .SetProperty(w => w.UpdatedAt, _ => DateTime.Now), ct);
            }

            return rows > 0;
        }

        public async Task<decimal> GetBalanceAsync(string userId, CancellationToken ct = default)
        {
            var w = await _ctx.User_Wallets.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId, ct);
            return w?.Balance ?? 0m;
        }
    }
}
