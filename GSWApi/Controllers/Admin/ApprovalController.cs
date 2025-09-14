using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GSWApi.Controllers.Admin
{
    
    [Authorize(Roles = "Admin,Staff")]
    [Route("api/admin/approval")]
    [ApiController]
    public class ApprovalController : ControllerBase
    {
        private readonly IApprovalRepository _approvalRepo;
        private readonly DBContext _context;

        public ApprovalController(IApprovalRepository approvalRepo, DBContext context)
        {
            _approvalRepo = approvalRepo;
            _context = context;
        }

        private static string? NormalizeStatus(string? raw)
        {
            if (string.IsNullOrWhiteSpace(raw)) return null;
            var s = raw.Trim().ToLowerInvariant();

            // map các biến thể thường gặp
            if (s is "approve" or "approved" or "apporve") return "Approved";
            if (s is "reject" or "rejected") return "Rejected";

            return null;
        }

        [HttpPost("game/{id:int}")]
        public async Task<IActionResult> ApproveGame(int id, [FromBody] ApprovalActionDTO dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Status))
                return BadRequest(new { success = false, message = "Status must not be empty." });

            var normalized = NormalizeStatus(dto.Status);
            if (normalized is null)
                return BadRequest(new { success = false, message = "Status must be 'Approved' or 'Rejected'." });

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { success = false, message = "You are not authorized or userId is missing." });

            var ok = await _approvalRepo.ApproveGameAsync(id, normalized, userId, dto.Note);
            if (!ok)
                return NotFound(new { success = false, message = "Game not found or not in Pending state." });

            return Ok(new { success = true, data = new { id, status = normalized } });
        }

        [HttpPost("refund/{id:int}")]
        public async Task<IActionResult> ApproveRefund(int id, [FromBody] ApprovalActionDTO dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Status))
                return BadRequest(new { success = false, message = "Status must not be empty." });

            var normalized = NormalizeStatus(dto.Status);
            if (normalized is null)
                return BadRequest(new { success = false, message = "Status must be 'Approved' or 'Rejected'." });

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { success = false, message = "You are not authorized or userId is missing." });

            // Quan trọng: Repo sẽ vừa đổi trạng thái Refund, ghi lịch sử,
            // và (sau khi bạn thêm code như đã gửi trước đó) tạo DepositWithdrawTransaction tương ứng.
            var ok = await _approvalRepo.ApproveRefundAsync(id, normalized, userId, dto.Note);
            if (!ok)
                return NotFound(new { success = false, message = "Refund request not found or not in Pending state." });

            return Ok(new { success = true, data = new { id, status = normalized } });
        }

        [HttpGet("game/{id:int}/history")]
        public async Task<IActionResult> GetGameHistory(int id)
        {
            var history = await _context.ApprovalHistories
                .Where(h => h.EntityType == "Game" && h.EntityId == id)
                .OrderBy(h => h.ChangedAt)
                .ToListAsync();

            return Ok(new { success = true, data = history });
        }

        [HttpGet("refund/{id:int}/history")]
        public async Task<IActionResult> GetRefundHistory(int id)
        {
            var history = await _context.ApprovalHistories
                .Where(h => h.EntityType == "Refund" && h.EntityId == id)
                .OrderBy(h => h.ChangedAt)
                .ToListAsync();

            return Ok(new { success = true, data = history });
        }
    }
}
