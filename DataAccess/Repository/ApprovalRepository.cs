using BusinessModel.Model;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        public async Task<bool> ApproveGameAsync(int gameId, string status, string changedByUserId, string note)
        {
            var game = await _context.Games_Info.FindAsync(gameId);
            if (game == null) return false;

            
            var s = status?.Trim().ToUpperInvariant();
            string? newStatus = s switch
            {
                
                "APPROVED" or "SUCCESS" or "SUCCESSED" or "SUCCEEDED" => "Approved",
                
                "REJECTED" or "FAILED" or "FAIL" => "Rejected",
                _ => null
            };
            if (newStatus == null) return false;

            
            if (!string.Equals(game.Status, newStatus, StringComparison.OrdinalIgnoreCase))
            {
                game.Status = newStatus;
            }

            
            _context.ApprovalHistories.Add(new ApprovalHistory
            {
                EntityType = "Game",
                EntityId = gameId,
                Status = newStatus,
                ChangedByUserId = changedByUserId,
                ChangedAt = DateTime.Now,
                Note = note
            });

            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<bool> ApproveRefundAsync(int refundId, string status, string changedByUserId, string note)
        {
            await using var tx = await _context.Database.BeginTransactionAsync();

            var refund = await _context.Store_RefundRequests
                .Include(r => r.Order).ThenInclude(o => o.OrderDetails)
                .FirstOrDefaultAsync(r => r.ID == refundId);

            if (refund == null) return false;

            // Chỉ xử lý khi đang Pending
            if (!string.Equals(refund.Status, "PENDING", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(refund.Status, "Pending", StringComparison.OrdinalIgnoreCase))
                return false;

            
            var s = status?.Trim().ToUpperInvariant();
            var decision = s switch
            {
                "SUCCESS" or "SUCCESSED" or "APPROVED" => "APPROVED",
                "FAILED" or "FAIL" or "REJECTED" => "REJECTED",
                _ => null
            };
            if (decision == null) return false;

            refund.Status = decision;

            _context.ApprovalHistories.Add(new ApprovalHistory
            {
                EntityType = "Refund",
                EntityId = refundId,
                Status = refund.Status,
                ChangedByUserId = changedByUserId,
                ChangedAt = DateTime.Now,
                Note = note
            });

            if (decision == "APPROVED")
            {
                // Xác định user được hoàn
                var beneficiaryUserId = refund.UserID ?? refund.Order?.UserID;
                if (string.IsNullOrWhiteSpace(beneficiaryUserId))
                    throw new InvalidOperationException("Refund recipient not identified.");

                // Tính số tiền hoàn
                decimal amount = 0m;

                var refundAmountProp = refund.GetType().GetProperty("RefundAmount");
                var amountProp = refund.GetType().GetProperty("Amount");
                if (refundAmountProp != null) amount = (decimal?)refundAmountProp.GetValue(refund) ?? 0m;
                if (amount <= 0m && amountProp != null) amount = (decimal?)amountProp.GetValue(refund) ?? 0m;

                if (amount <= 0m && refund.Order != null)
                {
                    var details = refund.Order.OrderDetails;
                    if (details != null && details.Any())
                    {
                        var sample = details.First();
                        var qProp = sample.GetType().GetProperty("Quantity");
                        var pProp = sample.GetType().GetProperty("UnitPrice");
                        if (pProp != null)
                        {
                            amount = (qProp != null)
                                ? details.Sum(d => ((int?)qProp.GetValue(d) ?? 1) * ((decimal?)pProp.GetValue(d) ?? 0m))
                                : details.Sum(d => (decimal?)pProp.GetValue(d) ?? 0m);
                        }
                    }

                    if (amount <= 0m)
                    {
                        var totalProp = refund.Order.GetType().GetProperty("TotalAmount");
                        if (totalProp != null) amount = (decimal?)totalProp.GetValue(refund.Order) ?? 0m;
                    }
                }

                if (amount <= 0m)
                    throw new InvalidOperationException("The refund amount must be greater than 0.");

                // Cộng ví 
                var wallet = await _context.User_Wallets.FirstOrDefaultAsync(w => w.UserId == beneficiaryUserId);
                if (wallet == null)
                {
                    wallet = new UserWallet { UserId = beneficiaryUserId, Balance = 0m, UpdatedAt = DateTime.Now };
                    _context.User_Wallets.Add(wallet);
                    await _context.SaveChangesAsync();
                }

                wallet.Balance += amount;
                wallet.UpdatedAt = DateTime.Now;

                // Ghi transaction ví (Status = "Success")
                var dwTx = new DepositWithdrawTransaction
                {
                    UserId = beneficiaryUserId,
                    Amount = amount,
                    Type = "DEPOSIT",
                    Status = "Success",
                    CreatedAt = DateTime.Now,
                    ApprovedAt = DateTime.Now,
                    ApprovedBy = changedByUserId,
                    Note = $"Refund for Order #{refund.OrderID} (Refund #{refundId})"
                };
                _context.DepositWithdrawTransactions.Add(dwTx);
                await _context.SaveChangesAsync(); 

                _context.ApprovalHistories.Add(new ApprovalHistory
                {
                    EntityType = "DepositWithdraw",
                    EntityId = dwTx.Id,
                    Status = dwTx.Status,
                    ChangedByUserId = changedByUserId,
                    ChangedAt = DateTime.Now,
                    Note = $"Auto-created by refund approval #{refundId}"
                });

                // Xóa game khỏi Library 
                if (refund.Order?.OrderDetails != null && refund.Order.OrderDetails.Any())
                {
                    var gameIds = refund.Order.OrderDetails.Select(d => d.GameID).Distinct().ToList();
                    var libItems = await _context.Store_Library
                        .Where(l => l.UserID == beneficiaryUserId && gameIds.Contains(l.GamesID))
                        .ToListAsync();

                    if (libItems.Count > 0)
                        _context.Store_Library.RemoveRange(libItems);
                }

                
                if (refund.Order != null)
                {
                    refund.Order.Status = "REFUNDED";
                }
            }

            await _context.SaveChangesAsync();
            await tx.CommitAsync();
            return true;
        }

    }
}
