using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GSWApi.Controllers.Store
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreThreadReplyController : ControllerBase
    {
        private readonly IStoreThreadReplyRepository _repository;

        public StoreThreadReplyController(IStoreThreadReplyRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("thread/{threadId}")]
        public async Task<IActionResult> GetRepliesByThreadId(int threadId)
        {
            var replies = await _repository.GetAllByThreadIdAsync(threadId);
            return Ok(new { success = true, data = replies });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StoreThreadReplyDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.ThreadComment))
                return BadRequest(new { success = false, message = "Comment is required." });

            var result = await _repository.CreateAsync(dto);
            return Ok(new { success = true, message = "Reply created.", data = result });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repository.DeleteAsync(id);
            if (!success)
                return NotFound(new { success = false, message = "Reply not found." });

            return Ok(new { success = true, message = "Reply deleted." });
        }
    }
}
