using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GSWApi.Controllers.PaymentMethod
{
    [ApiController]
    [Route("api/wallet")]
    [Authorize]
    public class DepositWithdrawController : ControllerBase
    {
        private readonly DBContext _ctx;
        private readonly IWalletRepository _walletRepo;
        private readonly IDepositWithdrawRepository _txRepo;

        public DepositWithdrawController(DBContext ctx, IWalletRepository walletRepo, IDepositWithdrawRepository txRepo)
        {
            _ctx = ctx;
            _walletRepo = walletRepo;
            _txRepo = txRepo;
        }

        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        // GET /api/wallet -> xem số dư
        [HttpGet]
        public async Task<ActionResult<WalletSummaryDTO>> GetMyWallet(CancellationToken ct)
        {
            var w = await _walletRepo.GetOrCreateAsync(CurrentUserId, ct);
            return Ok(new WalletSummaryDTO { Balance = w.Balance, UpdatedAt = w.UpdatedAt });
        }
        [HttpPost("wallet-pay")]
        public async Task<IActionResult> PayWithWallet([FromBody] WalletPayRequestDTO req, CancellationToken ct)
        {
            if (req == null || req.OrderId <= 0)
                return BadRequest(new { message = "Invalid OrderId" });

            // Lấy đơn + chi tiết (để tính tiền & cấp game)
            var order = await _ctx.Store_Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.ID == req.OrderId, ct);

            if (order == null)
                return NotFound(new { message = "No order found." });

            if (string.IsNullOrWhiteSpace(order.UserID) || order.UserID != CurrentUserId)
                return Forbid();

            // Idempotency: đã thanh toán rồi thì trả về OK
            if (string.Equals(order.Status, "COMPLETED", StringComparison.OrdinalIgnoreCase))
            {
                return Ok(new
                {
                    message = "Order was already paid.",
                    orderId = order.ID,
                    orderCode = order.OrderCode,
                    status = order.Status
                });
            }

            // Nếu đơn ở trạng thái FAILED hay bị huỷ thì chặn
            if (string.Equals(order.Status, "FAILED", StringComparison.OrdinalIgnoreCase))
                return Conflict(new { message = "Order is FAILED. Please create a new order." });

            // Tính số tiền cần thanh toán: ưu tiên sum từ details để chống sai lệch
            var amountFromDetails = order.OrderDetails?.Sum(d => d.UnitPrice) ?? 0m;
            var amount = amountFromDetails > 0 ? amountFromDetails : order.TotalAmount;

            if (amount <= 0)
                return BadRequest(new { message = "Order total amount is invalid." });

            // (Tuỳ chọn) đồng bộ lại TotalAmount nếu sai
            if (amountFromDetails > 0 && order.TotalAmount != amountFromDetails)
            {
                order.TotalAmount = amountFromDetails;
            }

            // Bắt đầu transaction để đảm bảo nhất quán
            await using var dbtx = await _ctx.Database.BeginTransactionAsync(ct);
            try
            {
                // Trừ ví nếu đủ (atomic ở tầng repo)
                var ok = await _walletRepo.DecreaseIfEnoughAsync(CurrentUserId, amount, ct);
                if (!ok)
                {
                    var bal = await _walletRepo.GetBalanceAsync(CurrentUserId, ct);
                    await dbtx.RollbackAsync(ct);
                    return Conflict(new { message = "Insufficient wallet balance.", balance = bal, required = amount });
                }

                // Cập nhật trạng thái đơn -> COMPLETED
                order.Status = "COMPLETED";
                await _ctx.SaveChangesAsync(ct);

                // Cấp game vào Store_Library (tránh trùng)
                var gameIds = order.OrderDetails?.Select(d => d.GameID).Distinct().ToList() ?? new List<int>();
                if (gameIds.Count > 0)
                {
                    var existedGameIds = await _ctx.Store_Library
                        .Where(x => x.UserID == CurrentUserId && gameIds.Contains(x.GamesID))
                        .Select(x => x.GamesID)
                        .ToListAsync(ct);

                    var toInsert = gameIds.Except(existedGameIds).ToList();

                    if (toInsert.Count > 0)
                    {
                        var now = DateTime.Now;
                        var newLibs = toInsert.Select(gid => new StoreLibrary
                        {
                            UserID = CurrentUserId,
                            GamesID = gid,
                            CreatedAt = now
                        });

                        await _ctx.Store_Library.AddRangeAsync(newLibs, ct);
                        await _ctx.SaveChangesAsync(ct);
                    }
                }

                // (Tuỳ chọn) Ghi log giao dịch Payment nếu bạn có entity PaymentTransaction
                // _ctx.PaymentTransactions.Add(new PaymentTransaction { ... });

                await dbtx.CommitAsync(ct);

                return Ok(new
                {
                    message = "Wallet payment succeeded.",
                    orderId = order.ID,
                    orderCode = order.OrderCode,
                    status = order.Status,
                    paidAmount = amount
                });
            }
            catch
            {
                await dbtx.RollbackAsync(ct);
                throw;
            }
        }
        // GET /api/wallet/transactions/my?take=50
        [HttpGet("transactions/my")]
        public async Task<ActionResult<IEnumerable<DepositWithdrawListItemDTO>>> MyTransactions([FromQuery] int take = 50, CancellationToken ct = default)
        {
            var list = await _txRepo.GetByUserAsync(CurrentUserId, Math.Clamp(take, 1, 200), ct);
            var dto = list.Select(x => new DepositWithdrawListItemDTO
            {
                Id = x.Id,
                Amount = x.Amount,
                Type = x.Type,
                Status = x.Status,
                CreatedAt = x.CreatedAt,
                ApprovedAt = x.ApprovedAt,
                ApprovedBy = x.ApprovedBy,
                Note = x.Note
            });
            return Ok(dto);
        }

        // POST /api/wallet/transactions -> tạo yêu cầu nạp/rút
        [HttpPost("transactions")]
        public async Task<IActionResult> Create([FromBody] DepositWithdrawRequestDTO model, CancellationToken ct)
        {
            if (model.Amount <= 0) return BadRequest("Amount must be > 0.");
            var type = model.Type?.Trim().ToUpperInvariant();
            if (type is not ("DEPOSIT" or "WITHDRAW"))
                return BadRequest("Type must be DEPOSIT or WITHDRAW.");

            await _walletRepo.GetOrCreateAsync(CurrentUserId, ct);

            // Nếu là rút: kiểm tra sơ bộ để UX tốt (kiểm cuối vẫn làm khi duyệt)
            if (type == "WITHDRAW")
            {
                var bal = await _walletRepo.GetBalanceAsync(CurrentUserId, ct);
                if (bal < model.Amount) return BadRequest("Insufficient balance.");
            }

            var tx = await _txRepo.CreateAsync(new DepositWithdrawTransaction
            {
                UserId = CurrentUserId,
                Amount = model.Amount,
                Type = type!,
                Note = model.Note
            }, ct);

            // Log trạng thái Pending
            _ctx.ApprovalHistories.Add(new ApprovalHistory
            {
                EntityType = "DepositWithdraw",
                EntityId = tx.Id,
                Status = "Pending",
                ChangedByUserId = CurrentUserId,
                ChangedAt = DateTime.Now,
                Note = "User submitted request"
            });
            await _ctx.SaveChangesAsync(ct);

            return CreatedAtAction(nameof(GetById), new { id = tx.Id }, new { tx.Id, tx.Status });
        }

        // GET /api/wallet/transactions/{id}
        [HttpGet("transactions/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken ct)
        {
            var tx = await _txRepo.GetByIdAsync(id, ct);
            if (tx == null || tx.UserId != CurrentUserId) return NotFound();
            return Ok(tx);
        }

        // ADMIN/MOD: danh sách pending
        [HttpGet("transactions/pending")]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> Pending([FromQuery] int page = 1, [FromQuery] int size = 20, CancellationToken ct = default)
        {
            page = Math.Max(1, page); size = Math.Clamp(size, 1, 100);
            var skip = (page - 1) * size;
            var total = await _txRepo.CountPendingAsync(ct);
            var items = await _txRepo.GetPendingAsync(skip, size, ct);
            return Ok(new { total, page, size, items });
        }

        // ADMIN/MOD: duyệt
        [HttpPost("transactions/approve")]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> Approve([FromBody] DepositWithdrawApproveDTO model, CancellationToken ct)
        {
            var status = model.Status?.Trim().ToUpperInvariant();
            if (status is not ("APPROVED" or "REJECTED"))
                return BadRequest("Status must be Approved or Rejected.");

            var tx = await _txRepo.GetByIdAsync(model.Id, ct);
            if (tx == null) return NotFound();
            if (tx.Status != "Pending") return BadRequest("Transaction already processed.");

            using var dbtx = await _ctx.Database.BeginTransactionAsync(ct);
            try
            {
                tx.Status = status!;
                tx.ApprovedAt = DateTime.Now;
                tx.ApprovedBy = CurrentUserId;
                if (!string.IsNullOrWhiteSpace(model.Note)) tx.Note = model.Note;

                if (status == "APPROVED")
                {
                    // NẠP: cộng tiền (atomic)
                    if (tx.Type == "DEPOSIT")
                    {
                        await _walletRepo.IncreaseAsync(tx.UserId, tx.Amount, ct);
                    }
                    else // RÚT: chỉ trừ nếu đủ (atomic). Nếu fail => báo lỗi, KHÔNG duyệt.
                    {
                        var ok = await _walletRepo.DecreaseIfEnoughAsync(tx.UserId, tx.Amount, ct);
                        if (!ok)
                        {
                            return BadRequest("User balance changed; now insufficient.");
                        }
                    }
                }

                await _txRepo.UpdateAsync(tx, ct);

                _ctx.ApprovalHistories.Add(new ApprovalHistory
                {
                    EntityType = "DepositWithdraw",
                    EntityId = tx.Id,
                    Status = tx.Status,
                    ChangedByUserId = CurrentUserId,
                    ChangedAt = DateTime.Now,
                    Note = model.Note
                });
                await _ctx.SaveChangesAsync(ct);

                await dbtx.CommitAsync(ct);
            }
            catch
            {
                await dbtx.RollbackAsync(ct);
                throw;
            }

            return Ok(new { tx.Id, tx.Status });
        }
    }
}
