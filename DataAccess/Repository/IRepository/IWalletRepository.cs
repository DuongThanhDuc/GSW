using BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IWalletRepository
    {
        Task<UserWallet> GetOrCreateAsync(string userId, CancellationToken ct = default);

        // Cộng tiền (nạp) – atomic
        Task IncreaseAsync(string userId, decimal amount, CancellationToken ct = default);

        // Trừ tiền (rút) – chỉ trừ nếu đủ, trả về true nếu trừ thành công
        Task<bool> DecreaseIfEnoughAsync(string userId, decimal amount, CancellationToken ct = default);

        Task<decimal> GetBalanceAsync(string userId, CancellationToken ct = default);
    }
}
