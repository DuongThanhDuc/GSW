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
    public class StoreThreadController : ControllerBase
    {
        private readonly IStoreThreadRepository _repository;
        private readonly Cloudinary _cloudinary;

        public StoreThreadController(IStoreThreadRepository repository, IOptions<CloudinarySettings> settings)
        {
            _repository = repository;

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
        public async Task<IActionResult> Create([FromForm] StoreThreadDTO dto, IFormFile? image)
        {
            if (string.IsNullOrWhiteSpace(dto.ThreadTitle) || string.IsNullOrWhiteSpace(dto.ThreadDescription))
                return BadRequest(new { success = false, message = "Thread title and description are required." });

            if (image != null)
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(image.FileName, image.OpenReadStream()),
                    Folder = "store/threads"
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

                dto.ThreadImageUrl = uploadResult.SecureUrl.ToString();
            }

            var result = await _repository.CreateAsync(dto);
            return Ok(new { success = true, message = "Thread created.", data = result });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] StoreThreadDTO dto, IFormFile? image)
        {
            dto.Id = id;

            if (image != null)
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(image.FileName, image.OpenReadStream()),
                    Folder = "store/threads"
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
    }
}
