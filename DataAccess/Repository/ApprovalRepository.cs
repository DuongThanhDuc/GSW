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

            game.Status = status;

            _context.ApprovalHistories.Add(new ApprovalHistory
            {
                EntityType = "Game",
                EntityId = gameId,
                Status = status,
                ChangedByUserId = changedByUserId,
                ChangedAt = DateTime.Now,
                Note = note
            });

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ApproveRefundAsync(int refundId, string status, string changedByUserId, string note)
        {
            // Load kèm Order và OrderDetails (nếu có) để dự phòng tính tiền
            var refund = await _context.Store_RefundRequests
                .Include(r => r.Order)
                    .ThenInclude(o => o.OrderDetails)
                .FirstOrDefaultAsync(r => r.ID == refundId);

            if (refund == null) return false;

            // Chỉ xử lý khi đang Pending để tránh cộng ví hai lần
            if (!string.Equals(refund.Status, "Pending", StringComparison.OrdinalIgnoreCase))
                return false;

            await using var tx = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1) Cập nhật trạng thái Refund + ghi lịch sử
                refund.Status = status;

                _context.ApprovalHistories.Add(new ApprovalHistory
                {
                    EntityType = "Refund",
                    EntityId = refundId,
                    Status = status,
                    ChangedByUserId = changedByUserId,
                    ChangedAt = DateTime.Now,
                    Note = note
                });

                // 2) Nếu Approved -> cộng tiền vào ví + TẠO DepositWithdrawTransaction
                if (string.Equals(status, "Approved", StringComparison.OrdinalIgnoreCase))
                {
                    // Xác định user nhận hoàn: ưu tiên Refund.UserID, fallback Order.UserID
                    var beneficiaryUserId = refund.UserID ?? refund.Order?.UserID;
                    if (string.IsNullOrWhiteSpace(beneficiaryUserId))
                        throw new InvalidOperationException("Không xác định được người nhận hoàn tiền.");

                    // Tính số tiền hoàn
                    decimal amount = 0m;

                    // 2.1 Ưu tiên trường RefundAmount hoặc Amount trên request
                    var refundAmountProp = refund.GetType().GetProperty("RefundAmount");
                    var amountProp = refund.GetType().GetProperty("Amount");
                    if (refundAmountProp != null)
                        amount = (decimal?)refundAmountProp.GetValue(refund) ?? 0m;
                    if (amount <= 0m && amountProp != null)
                        amount = (decimal?)amountProp.GetValue(refund) ?? 0m;

                    // 2.2 Nếu vẫn 0, fallback: tổng OrderDetails (Quantity * UnitPrice) hoặc chỉ UnitPrice; nếu không có nữa, thử TotalAmount
                    if (amount <= 0m && refund.Order != null)
                    {
                        if (refund.Order.OrderDetails != null && refund.Order.OrderDetails.Any())
                        {
                            var sample = refund.Order.OrderDetails.First();
                            var qProp = sample.GetType().GetProperty("Quantity");
                            var pProp = sample.GetType().GetProperty("UnitPrice");

                            if (pProp != null)
                            {
                                if (qProp != null)
                                {
                                    amount = refund.Order.OrderDetails.Sum(d =>
                                    {
                                        var q = (int?)(qProp.GetValue(d) as int?) ?? 1;
                                        var p = (decimal?)(pProp.GetValue(d) as decimal?) ?? 0m;
                                        return q * p;
                                    });
                                }
                                else
                                {
                                    amount = refund.Order.OrderDetails.Sum(d =>
                                        (decimal?)(pProp.GetValue(d) as decimal?) ?? 0m);
                                }
                            }
                        }

                        if (amount <= 0m)
                        {
                            var totalProp = refund.Order.GetType().GetProperty("TotalAmount");
                            if (totalProp != null)
                                amount = (decimal?)(totalProp.GetValue(refund.Order) as decimal?) ?? 0m;
                        }
                    }

                    if (amount <= 0m)
                        throw new InvalidOperationException("Số tiền hoàn phải lớn hơn 0.");

                    // 2.3 Cập nhật ví (tạo ví nếu chưa có)
                    var wallet = await _context.User_Wallets
                        .FirstOrDefaultAsync(w => w.UserId == beneficiaryUserId);

                    if (wallet == null)
                    {
                        wallet = new UserWallet
                        {
                            UserId = beneficiaryUserId,
                            Balance = 0m,
                            UpdatedAt = DateTime.UtcNow
                        };
                        _context.User_Wallets.Add(wallet);
                        await _context.SaveChangesAsync(); 
                    }

                    wallet.Balance += amount;
                    wallet.UpdatedAt = DateTime.Now;

                    // 2.4 GHI NHẬN vào bảng Deposit/Withdraw để phần UI hiển thị
                    var dwTx = new DepositWithdrawTransaction
                    {
                        UserId = beneficiaryUserId,
                        Amount = amount,
                        Type = "DEPOSIT",          
                        Status = "Approved",      
                        CreatedAt = DateTime.Now,
                        ApprovedAt = DateTime.Now,
                        ApprovedBy = changedByUserId,
                        Note = $"Refund for Order #{refund.OrderID} (Refund #{refundId})"
                    };
                    _context.DepositWithdrawTransactions.Add(dwTx);
                  
                    _context.ApprovalHistories.Add(new ApprovalHistory
                    {
                        EntityType = "DepositWithdraw",
                        
                        Status = dwTx.Status,
                        ChangedByUserId = changedByUserId,
                        ChangedAt = DateTime.Now,
                        Note = $"Auto-created by refund approval #{refundId}"
                    });
                }

                await _context.SaveChangesAsync();
                await tx.CommitAsync();
                return true;
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }
    }
}
