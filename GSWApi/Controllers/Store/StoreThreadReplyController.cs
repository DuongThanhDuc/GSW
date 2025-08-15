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
    public class StoreThreadReplyController : ControllerBase
    {
        private readonly IStoreThreadReplyRepository _repository;
        private readonly Cloudinary _cloudinary;

        public StoreThreadReplyController(IStoreThreadReplyRepository repository, IOptions<CloudinarySettings> settings)
        {

            // Setup Cloudinary
            _repository = repository;

            var account = new Account(
                settings.Value.CloudName,
                settings.Value.ApiKey,
                settings.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(account);
        }
        [HttpGet("thread/{threadId}")]
        public async Task<IActionResult> GetRepliesByThreadId(int threadId)
        {
            var replies = await _repository.GetAllByThreadIdAsync(threadId);
            return Ok(new { success = true, data = replies });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] StoreThreadReplyDTO dto, IFormFile? imageFile)
        {
            if (string.IsNullOrWhiteSpace(dto.ThreadComment) && imageFile == null)
                return BadRequest(new { success = false, message = "Either a comment or an image is required." });

            // Upload image to Cloudinary if provided
            if (imageFile != null && imageFile.Length > 0)
            {
                using var stream = imageFile.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(imageFile.FileName, stream),
                    Folder = "store_thread_replies" // Optional
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                if (uploadResult.Error != null)
                    return BadRequest(new { success = false, message = $"Image upload failed: {uploadResult.Error.Message}" });

                dto.CommentImageUrl = uploadResult.SecureUrl.ToString();
            }

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
