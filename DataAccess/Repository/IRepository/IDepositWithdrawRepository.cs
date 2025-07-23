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
        Task<DepositWithdrawTransaction> CreateAsync(DepositWithdrawTransaction tx);
        Task<List<DepositWithdrawTransaction>> GetAllAsync();
        Task<DepositWithdrawTransaction> GetByIdAsync(int id);
        Task ApproveAsync(int id, string status, string note, string adminId);
        Task<List<ApprovalHistory>> GetApprovalHistoryAsync(int entityId);
    }

}
