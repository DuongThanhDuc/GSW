using BusinessModel.Model;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore; // <-- thêm dòng này
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

            // Chỉ cho phép xử lý khi đang Pending để tránh cộng ví 2 lần
            if (!string.Equals(refund.Status, "Pending", StringComparison.OrdinalIgnoreCase))
                return false;

            // Bắt đầu transaction để đảm bảo atomic: đổi trạng thái + ghi history + cộng ví
            using var tx = await _context.Database.BeginTransactionAsync();
            try
            {
                // Cập nhật trạng thái refund
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

                // Nếu Approved -> cộng tiền vào ví
                if (string.Equals(status, "Approved", StringComparison.OrdinalIgnoreCase))
                {
                    // Xác định user nhận hoàn: ưu tiên Refund.UserID, fallback Order.UserID
                    // TODO: Đổi tên thuộc tính cho đúng schema của bạn nếu khác.
                    var beneficiaryUserId = refund.UserID ?? refund.Order?.UserID;
                    if (string.IsNullOrWhiteSpace(beneficiaryUserId))
                        throw new InvalidOperationException("Không xác định được người nhận hoàn tiền.");

                    // Tính số tiền hoàn. Ưu tiên trường RefundAmount trên yêu cầu hoàn.
                    // TODO: Nếu model của bạn dùng tên khác (vd: Amount), đổi lại cho đúng.
                    decimal amount = 0m;

                    // 1) Ưu tiên số tiền hoàn ghi trên request
                    var hasRefundAmountProp =
                        refund.GetType().GetProperty("RefundAmount") != null ||
                        refund.GetType().GetProperty("Amount") != null;

                    if (hasRefundAmountProp)
                    {
                        // Thử lấy theo thứ tự: RefundAmount -> Amount
                        var refundAmountProp = refund.GetType().GetProperty("RefundAmount");
                        var amountProp = refund.GetType().GetProperty("Amount");
                        if (refundAmountProp != null)
                            amount = (decimal?)(refundAmountProp.GetValue(refund) as decimal?) ?? 0m;
                        if (amount <= 0m && amountProp != null)
                            amount = (decimal?)(amountProp.GetValue(refund) as decimal?) ?? 0m;
                    }

                    // 2) Nếu chưa có, fallback: tổng OrderDetails hoặc TotalAmount
                    if (amount <= 0m && refund.Order != null)
                    {
                        // TODO: nếu có Quantity/UnitPrice thì nhân; nếu chỉ có UnitPrice thì Sum(UnitPrice)
                        if (refund.Order.OrderDetails != null && refund.Order.OrderDetails.Any())
                        {
                            var qProp = refund.Order.OrderDetails.First().GetType().GetProperty("Quantity");
                            var pProp = refund.Order.OrderDetails.First().GetType().GetProperty("UnitPrice");

                            if (pProp != null)
                            {
                                if (qProp != null)
                                {
                                    amount = refund.Order.OrderDetails
                                        .Select(d =>
                                        {
                                            var q = (int?)qProp.GetValue(d) ?? 1;
                                            var p = (decimal?)pProp.GetValue(d) ?? 0m;
                                            return q * p;
                                        }).Sum();
                                }
                                else
                                {
                                    amount = refund.Order.OrderDetails
                                        .Select(d => (decimal?)pProp.GetValue(d) ?? 0m)
                                        .Sum();
                                }
                            }
                        }

                        // Nếu vẫn 0 -> thử TotalAmount trên Order (nếu có)
                        if (amount <= 0m)
                        {
                            var totalProp = refund.Order.GetType().GetProperty("TotalAmount");
                            if (totalProp != null)
                                amount = (decimal?)(totalProp.GetValue(refund.Order) as decimal?) ?? 0m;
                        }
                    }

                    if (amount <= 0m)
                        throw new InvalidOperationException("Số tiền hoàn phải lớn hơn 0.");

                    // Cập nhật ví
                    // TODO: Đổi DbSet và model cho đúng (vd: _context.User_Wallets, entity UserWallet/User_Wallet)
                    var wallet = await _context.Set<UserWallet>()
                        .FirstOrDefaultAsync(w => w.UserId == beneficiaryUserId);

                    if (wallet == null)
                    {
                        wallet = new UserWallet
                        {
                            UserId = beneficiaryUserId,
                            Balance = 0m,
                            UpdatedAt = DateTime.UtcNow
                        };
                        _context.Set<UserWallet>().Add(wallet);
                        await _context.SaveChangesAsync(); // đảm bảo có Id nếu cần
                    }

                    wallet.Balance += amount;
                    wallet.UpdatedAt = DateTime.Now;

                  
                }

                await _context.SaveChangesAsync();
                await tx.CommitAsync();
                return true;
            }
            catch
            {
                await tx.RollbackAsync();
                throw; // để Controller trả 500 khi có lỗi nội bộ
            }
        }
    }
}
