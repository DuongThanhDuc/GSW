using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GSWApi.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
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

        [HttpPost("game/{id}")]
        public async Task<IActionResult> ApproveGame(int id, [FromBody] ApprovalActionDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Status))
                return BadRequest(new { message = "Status must not be empty." });

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { message = "You are not authorized or userId is missing." });

            bool ok = await _approvalRepo.ApproveGameAsync(id, dto.Status, userId, dto.Note);
            if (!ok)
                return NotFound(new { message = "Game not found." });

            return Ok(new { message = "Game approval updated successfully." });
        }

        [HttpPost("refund/{id}")]
        public async Task<IActionResult> ApproveRefund(int id, [FromBody] ApprovalActionDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Status))
                return BadRequest(new { message = "Status must not be empty." });

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { message = "You are not authorized or userId is missing." });

            bool ok = await _approvalRepo.ApproveRefundAsync(id, dto.Status, userId, dto.Note);
            if (!ok)
                return NotFound(new { message = "Refund request not found." });

            return Ok(new { message = "Refund approval updated successfully." });
        }


        [HttpGet("game/{id}/history")]
        public async Task<IActionResult> GetGameHistory(int id)
        {
            var history = await _context.ApprovalHistories
                .Where(h => h.EntityType == "Game" && h.EntityId == id)
                .OrderBy(h => h.ChangedAt)
                .ToListAsync();
            return Ok(history);
        }

        [HttpGet("refund/{id}/history")]
        public async Task<IActionResult> GetRefundHistory(int id)
        {
            var history = await _context.ApprovalHistories
                .Where(h => h.EntityType == "Refund" && h.EntityId == id)
                .OrderBy(h => h.ChangedAt)
                .ToListAsync();
            return Ok(history);
        }
    }
}
