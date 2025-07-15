using BusinessModel.Model;
using DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ApprovalRepository : IApprovalRepository
    {
        private readonly DBContext _context;

        public ApprovalRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> ApproveGameAsync(int gameId, string status, string adminId, string note)
        {
            var game = await _context.Games_Info.FindAsync(gameId);
            if (game == null) return false;

            game.Status = status;
            _context.ApprovalHistories.Add(new ApprovalHistory
            {
                EntityType = "Game",
                EntityId = gameId,
                Status = status,
                ChangedBy = adminId,
                ChangedAt = DateTime.Now,
                Note = note
            });
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ApproveRefundAsync(int refundId, string status, string adminId, string note)
        {
            var refund = await _context.Store_RefundRequests.FindAsync(refundId);
            if (refund == null) return false;

            refund.Status = status;
            _context.ApprovalHistories.Add(new ApprovalHistory
            {
                EntityType = "Refund",
                EntityId = refundId,
                Status = status,
                ChangedBy = adminId,
                ChangedAt = DateTime.Now,
                Note = note
            });
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
