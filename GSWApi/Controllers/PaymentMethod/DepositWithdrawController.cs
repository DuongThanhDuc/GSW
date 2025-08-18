using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Linq;

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
        public async Task<IActionResult> GetMyWallet(CancellationToken ct)
        {
            var w = await _walletRepo.GetOrCreateAsync(CurrentUserId, ct);
            var dto = new WalletSummaryDTO { Balance = w.Balance, UpdatedAt = w.UpdatedAt };

            return Ok(new { success = true, data = dto });
        }

        // POST /api/wallet/wallet-pay
        [HttpPost("wallet-pay")]
        public async Task<IActionResult> PayWithWallet([FromBody] WalletPayRequestDTO req, CancellationToken ct)
        {
            if (req == null || req.OrderId <= 0)
                return BadRequest(new { success = false, message = "Invalid OrderId" });

            var order = await _ctx.Store_Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.ID == req.OrderId, ct);

            if (order == null)
                return NotFound(new { success = false, message = "No order found." });

            if (string.IsNullOrWhiteSpace(order.UserID) || order.UserID != CurrentUserId)
                return StatusCode(StatusCodes.Status403Forbidden,
                                  new { success = false, message = "You cannot pay for this order." });

            if (string.Equals(order.Status, "COMPLETED", StringComparison.OrdinalIgnoreCase))
            {
                return Ok(new
                {
                    success = true,
                    data = new { orderId = order.ID, orderCode = order.OrderCode, status = order.Status },
                    message = "Order was already paid."
                });
            }

            if (string.Equals(order.Status, "FAILED", StringComparison.OrdinalIgnoreCase))
                return Conflict(new { success = false, message = "Order is FAILED. Please create a new order." });

            var amountFromDetails = order.OrderDetails?.Sum(d => d.UnitPrice) ?? 0m;
            var amount = amountFromDetails > 0 ? amountFromDetails : order.TotalAmount;

            if (amount <= 0)
                return BadRequest(new { success = false, message = "Order total amount is invalid." });

            if (amountFromDetails > 0 && order.TotalAmount != amountFromDetails)
                order.TotalAmount = amountFromDetails;

            await using var dbtx = await _ctx.Database.BeginTransactionAsync(ct);
            try
            {
                var ok = await _walletRepo.DecreaseIfEnoughAsync(CurrentUserId, amount, ct);
                if (!ok)
                {
                    var bal = await _walletRepo.GetBalanceAsync(CurrentUserId, ct);
                    await dbtx.RollbackAsync(ct);
                    return Conflict(new
                    {
                        success = false,
                        message = "Insufficient wallet balance.",
                        data = new { balance = bal, required = amount }
                    });
                }

                order.Status = "COMPLETED";
                await _ctx.SaveChangesAsync(ct);

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

                await dbtx.CommitAsync(ct);

                return Ok(new
                {
                    success = true,
                    data = new
                    {
                        orderId = order.ID,
                        orderCode = order.OrderCode,
                        status = order.Status,
                        paidAmount = amount
                    },
                    message = "Wallet payment succeeded."
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
        public async Task<IActionResult> MyTransactions([FromQuery] int take = 50, CancellationToken ct = default)
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

            return Ok(new { success = true, data = dto });
        }

        // POST /api/wallet/transactions -> tạo yêu cầu nạp/rút
        [HttpPost("transactions")]
        public async Task<IActionResult> Create([FromBody] DepositWithdrawRequestDTO model, CancellationToken ct)
        {
            if (model.Amount <= 0)
                return BadRequest(new { success = false, message = "Amount must be > 0." });

            var type = model.Type?.Trim().ToUpperInvariant();
            if (type is not ("DEPOSIT" or "WITHDRAW"))
                return BadRequest(new { success = false, message = "Type must be DEPOSIT or WITHDRAW." });

            await _walletRepo.GetOrCreateAsync(CurrentUserId, ct);

            if (type == "WITHDRAW")
            {
                var bal = await _walletRepo.GetBalanceAsync(CurrentUserId, ct);
                if (bal < model.Amount)
                    return BadRequest(new
                    {
                        success = false,
                        message = "Insufficient balance.",
                        data = new { balance = bal, required = model.Amount }
                    });
            }

            var tx = await _txRepo.CreateAsync(new DepositWithdrawTransaction
            {
                UserId = CurrentUserId,
                Amount = model.Amount,
                Type = type!,
                Note = model.Note
            }, ct);

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

            return CreatedAtAction(nameof(GetById), new { id = tx.Id },
                new { success = true, data = new { tx.Id, tx.Status } });
        }

        // GET /api/wallet/transactions/{id}
        [HttpGet("transactions/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken ct)
        {
            var tx = await _txRepo.GetByIdAsync(id, ct);
            if (tx == null || tx.UserId != CurrentUserId)
                return NotFound(new { success = false, message = "Transaction not found." });

            return Ok(new { success = true, data = tx });
        }

        // ADMIN/MOD: danh sách pending
        [HttpGet("transactions/pending")]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> Pending([FromQuery] int page = 1, [FromQuery] int size = 20, CancellationToken ct = default)
        {
            page = Math.Max(1, page);
            size = Math.Clamp(size, 1, 100);
            var skip = (page - 1) * size;

            var total = await _txRepo.CountPendingAsync(ct);
            var items = await _txRepo.GetPendingAsync(skip, size, ct);

            return Ok(new { success = true, data = new { total, page, size, items } });
        }

        // ADMIN/MOD: duyệt
        [HttpPost("transactions/approve")]
        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> Approve([FromBody] DepositWithdrawApproveDTO model, CancellationToken ct)
        {
            var status = model.Status?.Trim().ToUpperInvariant();
            if (status is not ("APPROVED" or "REJECTED"))
                return BadRequest(new { success = false, message = "Status must be Approved or Rejected." });

            var tx = await _txRepo.GetByIdAsync(model.Id, ct);
            if (tx == null)
                return NotFound(new { success = false, message = "Transaction not found." });

            if (tx.Status != "Pending")
                return BadRequest(new { success = false, message = "Transaction already processed." });

            await using var dbtx = await _ctx.Database.BeginTransactionAsync(ct);
            try
            {
                tx.Status = status!;
                tx.ApprovedAt = DateTime.Now;
                tx.ApprovedBy = CurrentUserId;
                if (!string.IsNullOrWhiteSpace(model.Note)) tx.Note = model.Note;

                if (status == "APPROVED")
                {
                    if (tx.Type == "DEPOSIT")
                    {
                        await _walletRepo.IncreaseAsync(tx.UserId, tx.Amount, ct);
                    }
                    else
                    {
                        var ok = await _walletRepo.DecreaseIfEnoughAsync(tx.UserId, tx.Amount, ct);
                        if (!ok)
                        {
                            await dbtx.RollbackAsync(ct);
                            return BadRequest(new { success = false, message = "User balance changed; now insufficient." });
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

            return Ok(new { success = true, data = new { tx.Id, tx.Status } });
        }
    }
}
