using BusinessModel.Model;
using DataAccess.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using Microsoft.EntityFrameworkCore;

namespace GSWApi.Controllers.PaymentMethod
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepositWithdrawController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DepositWithdrawController(DBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // User nạp/rút
        [HttpPost]
        public async Task<IActionResult> Request([FromBody] DepositWithdrawRequestDTO model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var tx = new DepositWithdrawTransaction
            {
                UserId = userId,
                Amount = model.Amount,
                Type = model.Type,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow,
                Note = model.Note
            };

            _context.DepositWithdrawTransactions.Add(tx);
            await _context.SaveChangesAsync();

            return Ok(new { tx.Id, tx.Status });
        }

        // Admin duyệt/rà soát
        [HttpPost("{id}/approve")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Approve(int id, [FromBody] DepositWithdrawApproveDTO model)
        {
            var tx = await _context.DepositWithdrawTransactions.FindAsync(id);
            if (tx == null) return NotFound();

            tx.Status = model.Status;
            tx.ApprovedAt = DateTime.UtcNow;
            tx.ApprovedBy = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            tx.Note = model.Note;

            // Ghi log ApprovalHistory
            var approval = new ApprovalHistory
            {
                EntityType = "DepositWithdraw",
                EntityId = tx.Id,
                Status = model.Status,
                ChangedByUserId = tx.ApprovedBy,
                ChangedAt = tx.ApprovedAt ?? DateTime.UtcNow,
                Note = model.Note
            };
            _context.ApprovalHistories.Add(approval);

            await _context.SaveChangesAsync();

            return Ok(new { tx.Id, tx.Status });
        }

        // Lịch sử duyệt
        [HttpGet("{id}/approvals")]
        public async Task<IActionResult> GetApprovalHistory(int id)
        {
            var logs = await _context.ApprovalHistories
                .Where(x => x.EntityType == "DepositWithdraw" && x.EntityId == id)
                .OrderBy(x => x.ChangedAt)
                .ToListAsync();

            return Ok(logs);
        }
    }

}
