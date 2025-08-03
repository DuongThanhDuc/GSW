using BusinessModel.Model;
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

        public StoreThreadReplyController(
            IStoreThreadReplyRepository repository,
            IOptions<CloudinarySettings> settings)
        {
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
        public async Task<IActionResult> Create([FromForm] StoreThreadReplyDTO dto, IFormFile? image)
        {
            if (string.IsNullOrWhiteSpace(dto.ThreadComment))
                return BadRequest(new { success = false, message = "Comment is required." });

            if (image != null)
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(image.FileName, image.OpenReadStream()),
                    Folder = "store/thread-replies"
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                if (uploadResult.Error != null)
                {
                    return StatusCode(500, new
                    {
                        success = false,
                        message = $"Cloudinary upload error: {uploadResult.Error.Message}"
                    });
                }

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
    }
}
