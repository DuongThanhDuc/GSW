using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GSWApi.Controllers.Admin
{
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
            bool ok = await _approvalRepo.ApproveGameAsync(id, dto.Status, User.Identity.Name, dto.Note);
            return ok ? Ok() : NotFound();
        }

        [HttpPost("refund/{id}")]
        public async Task<IActionResult> ApproveRefund(int id, [FromBody] ApprovalActionDTO dto)
        {
            bool ok = await _approvalRepo.ApproveRefundAsync(id, dto.Status, User.Identity.Name, dto.Note);
            return ok ? Ok() : NotFound();
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
