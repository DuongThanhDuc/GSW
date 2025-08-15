using BusinessModel.Model;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class DepositWithdrawRepository : IDepositWithdrawRepository
    {
        private readonly DBContext _context;
        public DepositWithdrawRepository(DBContext context) => _context = context;

        public async Task<DepositWithdrawTransaction> CreateAsync(DepositWithdrawTransaction tx, CancellationToken ct = default)
        {
            tx.CreatedAt = DateTime.Now;
            tx.Status = "Pending";
            _context.DepositWithdrawTransactions.Add(tx);
            await _context.SaveChangesAsync(ct);
            return tx;
        }

        public Task<DepositWithdrawTransaction?> GetByIdAsync(int id, CancellationToken ct = default) =>
            _context.DepositWithdrawTransactions.FirstOrDefaultAsync(x => x.Id == id, ct);

        public Task<List<DepositWithdrawTransaction>> GetByUserAsync(string userId, int take = 50, CancellationToken ct = default) =>
            _context.DepositWithdrawTransactions.Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedAt).Take(take).ToListAsync(ct);

        public Task<int> CountPendingAsync(CancellationToken ct = default) =>
            _context.DepositWithdrawTransactions.CountAsync(x => x.Status == "Pending", ct);

        public Task<List<DepositWithdrawTransaction>> GetPendingAsync(int skip, int take, CancellationToken ct = default) =>
            _context.DepositWithdrawTransactions.Where(x => x.Status == "Pending")
                .OrderBy(x => x.CreatedAt).Skip(skip).Take(take).ToListAsync(ct);

        public async Task UpdateAsync(DepositWithdrawTransaction tx, CancellationToken ct = default)
        {
            _context.DepositWithdrawTransactions.Update(tx);
            await _context.SaveChangesAsync(ct);
        }
    }
}
