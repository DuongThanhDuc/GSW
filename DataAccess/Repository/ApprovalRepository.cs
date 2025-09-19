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

            
            if (status == "Successed" || status == "Success")
            {
                game.Status = "Purchased"; 
            }
            else if (status == "Failed" || status == "Failed")
            {
                game.Status = "Failed"; 
            }

            // Thêm lịch sử phê duyệt
            _context.ApprovalHistories.Add(new ApprovalHistory
            {
                EntityType = "Game",
                EntityId = gameId,
                Status = game.Status,
                ChangedByUserId = changedByUserId,
                ChangedAt = DateTime.Now,
                Note = note
            });

            // Cập nhật quyền sở hữu game của người dùng trong bảng Store_Library
            var userGame = await _context.Store_Library
                .FirstOrDefaultAsync(sl => sl.GamesID == gameId && sl.UserID == changedByUserId);

            if (userGame != null)
            {            
                _context.Store_Library.Remove(userGame); 
            }

            // Lưu thay đổi vào cơ sở dữ liệu
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<bool> ApproveRefundAsync(int refundId, string status, string changedByUserId, string note)
        {
            var refund = await _context.Store_RefundRequests
                .Include(r => r.Order).ThenInclude(o => o.OrderDetails)
                .FirstOrDefaultAsync(r => r.ID == refundId);

            if (refund == null) return false;

            // Chỉ xử lý khi đang Pending
            if (!string.Equals(refund.Status, "Pending", StringComparison.OrdinalIgnoreCase))
                return false;

            await using var tx = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1) Cập nhật trạng thái Refund + lịch sử
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

                // 2) Nếu Success → cộng ví + tạo bản ghi Deposit/Withdraw (Type=DEPOSIT, Status=Successed)
                if (string.Equals(status, "Success", StringComparison.OrdinalIgnoreCase))
                {
                    var beneficiaryUserId = refund.UserID ?? refund.Order?.UserID;
                    if (string.IsNullOrWhiteSpace(beneficiaryUserId))
                        throw new InvalidOperationException("Refund recipient not identified.");

                    decimal amount = 0m;

                    // Ưu tiên RefundAmount hoặc Amount trên request 
                    var refundAmountProp = refund.GetType().GetProperty("RefundAmount");
                    var amountProp = refund.GetType().GetProperty("Amount");
                    if (refundAmountProp != null) amount = (decimal?)refundAmountProp.GetValue(refund) ?? 0m;
                    if (amount <= 0m && amountProp != null) amount = (decimal?)amountProp.GetValue(refund) ?? 0m;

                    // Fallback: tính từ OrderDetails hoặc TotalAmount (nếu bạn có)
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

                    // Cập nhật ví (tạo nếu chưa có)
                    var wallet = await _context.User_Wallets.FirstOrDefaultAsync(w => w.UserId == beneficiaryUserId);
                    if (wallet == null)
                    {
                        wallet = new UserWallet { UserId = beneficiaryUserId, Balance = 0m, UpdatedAt = DateTime.Now };
                        _context.User_Wallets.Add(wallet);
                        await _context.SaveChangesAsync();
                    }

                    wallet.Balance += amount;
                    wallet.UpdatedAt = DateTime.Now;

                    
                    var dwTx = new DepositWithdrawTransaction
                    {
                        UserId = beneficiaryUserId,
                        Amount = amount,
                        Type = "DEPOSIT",
                        Status = "Successed",           
                        CreatedAt = DateTime.Now,
                        ApprovedAt = DateTime.Now,        
                        ApprovedBy = changedByUserId,
                        Note = $"Refund for Order #{refund.OrderID} (Refund #{refundId})"
                    };
                    _context.DepositWithdrawTransactions.Add(dwTx);
                 
                    _context.ApprovalHistories.Add(new ApprovalHistory
                    {
                        EntityType = "DepositWithdraw",
                        EntityId = dwTx.Id,            
                        Status = dwTx.Status,
                        ChangedByUserId = changedByUserId,
                        ChangedAt = DateTime.Now,
                        Note = $"Auto-created by refund approval #{refundId}"
                    });
                }

                // update order 
                var order = _context.Store_Orders.FirstOrDefault(x => x.ID == refund.OrderID);
                if (order == null)
                {
                    throw new InvalidOperationException("Order not found.");
                }
                else
                {
                    order.Status = "Refunded";
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
