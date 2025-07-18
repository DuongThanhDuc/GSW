using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IApprovalRepository
    {
        Task<bool> ApproveGameAsync(int gameId, string status, string changedByUserId, string note);
        Task<bool> ApproveRefundAsync(int refundId, string status, string changedByUserId, string note);

    }
}
