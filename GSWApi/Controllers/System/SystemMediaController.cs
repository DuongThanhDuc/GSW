using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;


namespace GSWApi.Controllers.System
{
    public class SystemMediaController : ControllerBase
    {
        private readonly ISystemMediaRepository _mediaRepository;
        private readonly Cloudinary _cloudinary;

        public SystemMediaController(ISystemMediaRepository mediaRepository, Cloudinary cloudinary)
        {
            _mediaRepository = mediaRepository;
            _cloudinary = cloudinary;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadMedia([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { success = false, message = "No file selected" });

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                Folder = "gameshop"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.StatusCode != global::System.Net.HttpStatusCode.OK)
                return StatusCode(500, new { success = false, message = "Cloudinary upload failed" });

            var mediaDto = await _mediaRepository.SaveMediaUrlAsync(uploadResult.SecureUrl.AbsoluteUri);

            return Ok(new
            {
                success = true,
                message = "Upload successful",
                data = mediaDto
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedia(int id)
        {
            var media = await _mediaRepository.GetByIdAsync(id);
            if (media == null)
                return NotFound(new { success = false, message = "Media not found" });

            return Ok(new { success = true, data = media });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedia()
        {
            var mediaList = await _mediaRepository.GetAllAsync();
            return Ok(new { success = true, data = mediaList });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedia(int id)
        {
            var result = await _mediaRepository.DeleteAsync(id);
            if (!result)
                return NotFound(new { success = false, message = "Media not found" });

            return Ok(new { success = true, message = "Media deleted" });
        }
    }
}
