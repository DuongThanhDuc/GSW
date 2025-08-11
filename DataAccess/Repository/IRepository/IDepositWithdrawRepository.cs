using BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IDepositWithdrawRepository
    {
        Task<DepositWithdrawTransaction> CreateAsync(DepositWithdrawTransaction tx, CancellationToken ct = default);
        Task<DepositWithdrawTransaction?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<List<DepositWithdrawTransaction>> GetByUserAsync(string userId, int take = 50, CancellationToken ct = default);
        Task<int> CountPendingAsync(CancellationToken ct = default);
        Task<List<DepositWithdrawTransaction>> GetPendingAsync(int skip, int take, CancellationToken ct = default);
        Task UpdateAsync(DepositWithdrawTransaction tx, CancellationToken ct = default);
    }
}
