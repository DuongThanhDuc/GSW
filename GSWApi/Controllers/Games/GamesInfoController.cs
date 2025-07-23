using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using GSWApi.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace GSWApi.Controllers.Games
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesInfoController : ControllerBase
    {
        private readonly IGamesInfoRepository _repository;
        private readonly GoogleDriveUploader _googleDriveUploader;
        private readonly Cloudinary _cloudinary;

        public GamesInfoController(
            IGamesInfoRepository repository,
            GoogleDriveUploader googleDriveUploader,
            IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _repository = repository;
            _googleDriveUploader = googleDriveUploader;

            var account = new Account(
                cloudinaryConfig.Value.CloudName,
                cloudinaryConfig.Value.ApiKey,
                cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(account);
        }

        // GET: api/GamesInfo/dto
        [HttpGet("dto")]
        public async Task<IActionResult> GetAllGamesDTO()
        {
            var games = await _repository.GetAllAsync();
            return Ok(new { success = true, data = games });
        }

        [HttpGet("dto/{id}")]
        public async Task<IActionResult> GetAllGamesByIDDTO(int id)
        {
            var games = await _repository.GetByIdAsync(id);
            return Ok(new { success = true, data = games });
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame(
             [FromForm] GamesInfoDTO dto,
             IFormFile installerFile,
             IFormFile coverImage)
        {
            if (installerFile == null || installerFile.Length == 0)
                return BadRequest(new { success = false, message = "Installer file is required." });

            // Upload installer to Google Drive
            try
            {
                dto.InstallerFilePath = await _googleDriveUploader.UploadInstallerAsync(installerFile);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Installer upload failed.", error = ex.Message });
            }

            // Upload cover image to Cloudinary
            if (coverImage != null && coverImage.Length > 0)
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(coverImage.FileName, coverImage.OpenReadStream()),
                    Folder = $"games/covers"
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                if (uploadResult.Error != null)
                {
                    return StatusCode(500, new { success = false, message = "Cover image upload failed.", error = uploadResult.Error.Message });
                }

                dto.CoverImagePath = uploadResult.SecureUrl.ToString();
            }

            var createdGame = await _repository.CreateAsync(dto);
            return Ok(new
            {
                success = true,
                message = "Game created successfully.",
                data = createdGame
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(
            int id,
            [FromForm] GamesInfoDTO dto,
            IFormFile installerFile,
            IFormFile coverImage)
        {
            if (id != dto.ID)
                return BadRequest(new { success = false, message = "ID mismatch." });

            if (installerFile != null && installerFile.Length > 0)
            {
                try
                {
                    dto.InstallerFilePath = await _googleDriveUploader.UploadInstallerAsync(installerFile);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { success = false, message = "Installer upload failed.", error = ex.Message });
                }
            }

            if (coverImage != null && coverImage.Length > 0)
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(coverImage.FileName, coverImage.OpenReadStream()),
                    Folder = $"games/covers"
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                if (uploadResult.Error != null)
                {
                    return StatusCode(500, new { success = false, message = "Cover image upload failed.", error = uploadResult.Error.Message });
                }

                dto.CoverImagePath = uploadResult.SecureUrl.ToString();
            }

            var success = await _repository.UpdateAsync(dto);
            if (!success)
                return NotFound(new { success = false, message = "Game not found." });

            return Ok(new { success = true, message = "Game updated successfully.", data = dto });
        }

        // DELETE: api/GamesInfo/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var success = await _repository.DeleteAsync(id);
            if (!success)
                return NotFound(new { success = false, message = "Game not found." });

            return Ok(new { success = true, message = "Game deleted successfully.", data = new { id } });
        }

        // POST: api/GamesInfo/{id}/active
        [HttpPost("{id}/active")]
        public async Task<IActionResult> ActiveGame(int id)
        {
            var success = await _repository.SetActiveStatusAsync(id, true);
            if (!success)
                return NotFound(new { success = false, message = "Game not found." });
            return Ok(new { success = true, message = "Game activated successfully." });
        }

        // POST: api/GamesInfo/{id}/deactive
        [HttpPost("{id}/deactive")]
        public async Task<IActionResult> DeactiveGame(int id)
        {
            var success = await _repository.SetActiveStatusAsync(id, false);
            if (!success)
                return NotFound(new { success = false, message = "Game not found." });
            return Ok(new { success = true, message = "Game deactivated successfully." });
        }

        // POST: api/GamesInfo/{id}/status
        public class UpdateGameStatusDTO
        {
            public string Status { get; set; }
        }

        [HttpPost("{id}/status")]
        public async Task<IActionResult> UpdateGameStatus(int id, [FromBody] UpdateGameStatusDTO dto)
        {
            var success = await _repository.UpdateStatusAsync(id, dto.Status);
            if (!success)
                return NotFound(new { success = false, message = "Game not found." });
            return Ok(new { success = true, message = $"Game status updated to {dto.Status}." });
        }
    }
}
