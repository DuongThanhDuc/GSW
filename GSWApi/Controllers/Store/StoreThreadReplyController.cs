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

        // POST: api/storethreadreply/upvote
        [HttpPost("upvote")]
        public async Task<IActionResult> ToggleReplyUpvote([FromBody] StoreThreadReplyUpvoteHistoryDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.UserId) || dto.ThreadCommentId <= 0)
                return BadRequest(new { success = false, message = "User ID and Reply ID are required." });

            var added = await _repository.ToggleReplyUpvoteAsync(dto.UserId, dto.ThreadCommentId);

            return Ok(new
            {
                success = true,
                message = added ? "Reply upvoted." : "Reply un-upvoted.",
                upvoted = added
            });
        }

        // GET: api/storethreadreply/upvotes
        [HttpGet("upvotes")]
        public async Task<IActionResult> GetAllReplyUpvotes()
        {
            var records = await _repository.GetAllReplyUpvotesAsync();
            return Ok(new { success = true, data = records });
        }

        // GET: api/storethreadreply/upvotes/{id}
        [HttpGet("upvotes/{id}")]
        public async Task<IActionResult> GetReplyUpvoteById(int id)
        {
            var record = await _repository.GetReplyUpvoteByIdAsync(id);
            if (record == null)
                return NotFound(new { success = false, message = "Upvote record not found." });

            return Ok(new { success = true, data = record });
        }

        // GET: api/StoreThreadReply/upvotes/search?query=...
        [HttpGet("upvotes/search")]
        public async Task<IActionResult> SearchReplyUpvotes([FromQuery] string query)
        {
            var replies = await _repository.SearchReplyUpvotesByUserAsync(query);
            return Ok(new { success = true, data = replies });
        }
    }
}
