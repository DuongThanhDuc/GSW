using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GSWApi.Controllers.Store
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreThreadController : ControllerBase
    {
        private readonly IStoreThreadRepository _repository;

        public StoreThreadController(IStoreThreadRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var threads = await _repository.GetAllAsync();
            return Ok(new { success = true, data = threads });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var thread = await _repository.GetByIdAsync(id);
            if (thread == null)
                return NotFound(new { success = false, message = "Thread not found." });

            return Ok(new { success = true, data = thread });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StoreThreadDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.ThreadTitle) || string.IsNullOrWhiteSpace(dto.ThreadDescription))
                return BadRequest(new { success = false, message = "Thread title and description are required." });

            var result = await _repository.CreateAsync(dto);
            return Ok(new { success = true, message = "Thread created.", data = result });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StoreThreadDTO dto)
        {
            dto.Id = id;
            var success = await _repository.UpdateAsync(dto);
            if (!success)
                return NotFound(new { success = false, message = "Thread not found." });

            return Ok(new { success = true, message = "Thread updated." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repository.DeleteAsync(id);
            if (!success)
                return NotFound(new { success = false, message = "Thread not found." });

            return Ok(new { success = true, message = "Thread deleted." });
        }

        [HttpPost("upvote")]
        public async Task<IActionResult> ToggleUpvote([FromBody] StoreThreadUpvoteHistoryDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.UserID) || dto.ThreadID <= 0)
                return BadRequest(new { success = false, message = "User ID and Thread ID are required." });

            var added = await _repository.ToggleUpvoteAsync(dto.UserID, dto.ThreadID);

            return Ok(new
            {
                success = true,
                message = added ? "Upvote added." : "Upvote removed.",
                upvoted = added
            });
        }

        // GET: api/storethread/upvotes
        [HttpGet("upvotes")]
        public async Task<IActionResult> GetAllUpvoteHistories()
        {
            var histories = await _repository.GetAllUpvoteHistoriesAsync();
            return Ok(new { success = true, data = histories });
        }

        // GET: api/storethread/upvotes/{id}
        [HttpGet("upvotes/{id}")]
        public async Task<IActionResult> GetUpvoteHistoryById(int id)
        {
            var history = await _repository.GetUpvoteHistoryByIdAsync(id);
            if (history == null)
                return NotFound(new { success = false, message = "Upvote history not found." });

            return Ok(new { success = true, data = history });
        }
    }
}
