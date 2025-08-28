using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using GSWApi.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GSWApi.Controllers.Store
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreThreadController : ControllerBase
    {
        private readonly IStoreThreadRepository _repository;
        private readonly Cloudinary _cloudinary;

        public StoreThreadController(IStoreThreadRepository repository, IOptions<CloudinarySettings> settings)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            if (settings == null || settings.Value == null)
                throw new ArgumentNullException(nameof(settings));

            var account = new Account(
                settings.Value.CloudName,
                settings.Value.ApiKey,
                settings.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(account);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var threads = await _repository.GetAllAsync();
            if (threads == null) return NotFound(new { success = false, message = "No threads found." });
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
        public async Task<IActionResult> Create([FromForm] StoreThreadDTO dto, IFormFile? imageFile)
        {
            if (dto == null) return BadRequest(new { success = false, message = "Invalid thread data." });
            if (string.IsNullOrWhiteSpace(dto.ThreadTitle) || string.IsNullOrWhiteSpace(dto.ThreadDescription))
                return BadRequest(new { success = false, message = "Thread title and description are required." });

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(imageFile.FileName, imageFile.OpenReadStream()),
                    Folder = "threads/images"
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                if (uploadResult == null || uploadResult.Error != null)
                    return StatusCode(500, new { success = false, message = $"Cloudinary Error: {uploadResult?.Error?.Message}" });

                dto.ThreadImageUrl = uploadResult.SecureUrl.ToString();
            }

            var result = await _repository.CreateAsync(dto);
            if (result == null) return StatusCode(500, new { success = false, message = "Failed to create thread." });

            return Ok(new { success = true, message = "Thread created.", data = result });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] StoreThreadDTO dto, IFormFile? imageFile)
        {
            if (dto == null) return BadRequest(new { success = false, message = "Invalid thread data." });
            dto.Id = id;

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(imageFile.FileName, imageFile.OpenReadStream()),
                    Folder = "threads/images"
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                if (uploadResult == null || uploadResult.Error != null)
                    return StatusCode(500, new { success = false, message = $"Cloudinary Error: {uploadResult?.Error?.Message}" });

                dto.ThreadImageUrl = uploadResult.SecureUrl.ToString();
            }

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
            if (dto == null) return BadRequest(new { success = false, message = "Invalid upvote data." });
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
            if (histories == null) return NotFound(new { success = false, message = "No upvote histories found." });
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

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId)) return BadRequest(new { success = false, message = "User ID is required." });

            var threads = await _repository.GetAllByUserIdAsync(userId);
            if (threads == null) return NotFound(new { success = false, message = "No threads found for this user." });

            return Ok(new { success = true, data = threads });
        }

        [HttpGet("upvotes/search")]
        public async Task<IActionResult> GetAllUpvoteHistoriesByUserSearch([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return BadRequest(new { success = false, message = "Search query is required." });

            var upvotes = await _repository.GetAllUpvoteHistoriesByUserSearchAsync(query);
            if (upvotes == null) return NotFound(new { success = false, message = "No upvotes found for this query." });

            return Ok(new { success = true, data = upvotes });
        }

    }
}
