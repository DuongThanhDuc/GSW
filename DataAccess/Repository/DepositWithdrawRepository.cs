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
    public class DepositWithdrawRepository : IDepositWithdrawRepository
    {
        private readonly DBContext _context;
        public DepositWithdrawRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<DepositWithdrawTransaction> CreateAsync(DepositWithdrawTransaction tx)
        {
            tx.CreatedAt = DateTime.UtcNow;
            tx.Status = "Pending";
            _context.DepositWithdrawTransactions.Add(tx);
            await _context.SaveChangesAsync();
            return tx;
        }

        public async Task<List<DepositWithdrawTransaction>> GetAllAsync()
        {
            return await _context.DepositWithdrawTransactions
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<DepositWithdrawTransaction> GetByIdAsync(int id)
        {
            return await _context.DepositWithdrawTransactions
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task ApproveAsync(int id, string status, string note, string adminId)
        {
            var tx = await _context.DepositWithdrawTransactions.FindAsync(id);
            if (tx == null) throw new Exception("Transaction not found");

            tx.Status = status;
            tx.ApprovedAt = DateTime.UtcNow;
            tx.ApprovedBy = adminId;
            tx.Note = note;

            // Add Approval History
            var approval = new ApprovalHistory
            {
                EntityType = "DepositWithdraw",
                EntityId = tx.Id,
                Status = status,
                ChangedByUserId = adminId,
                ChangedAt = DateTime.UtcNow,
                Note = note
            };
            _context.ApprovalHistories.Add(approval);

            await _context.SaveChangesAsync();
        }

        public async Task<List<ApprovalHistory>> GetApprovalHistoryAsync(int entityId)
        {
            return await _context.ApprovalHistories
                .Where(x => x.EntityType == "DepositWithdraw" && x.EntityId == entityId)
                .OrderBy(x => x.ChangedAt)
                .ToListAsync();
        }
    }

}
