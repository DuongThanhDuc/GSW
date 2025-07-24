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

        // POST: api/GamesInfo
        [HttpPost]
        public async Task<IActionResult> CreateGame(GamesInfoDTO dto)
        {
            var createdGame = await _repository.CreateAsync(dto);
            return Ok(new { success = true, message = "Game created successfully.", data = createdGame });
        }

        // PUT: api/GamesInfo/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, GamesInfoDTO dto)
        {
            if (id != dto.ID)
                return BadRequest(new { success = false, message = "ID mismatch." });

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

        // POST: api/GamesInfo/{id}/upload-installer
        [HttpPost("{id}/upload-installer")]
        public async Task<IActionResult> UploadInstallerFile(int id, IFormFile installerFile)
        {
            if (installerFile == null || installerFile.Length == 0)
                return BadRequest(new { success = false, message = "Installer file is required." });

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound(new { success = false, message = "Game not found." });

            try
            {
                var filePath = await _googleDriveUploader.UploadInstallerAsync(installerFile);

                // Manual mapping
                var editableDto = new GamesInfoDTO
                {
                    ID = existing.ID,
                    Title = existing.Title,
                    Description = existing.Description,
                    Price = existing.Price,
                    CoverImagePath = existing.CoverImagePath,
                    InstallerFilePath = filePath, // update only this
                    Status = existing.Status,
                    IsActive = existing.IsActive,
                };

                await _repository.UpdateAsync(editableDto);

                return Ok(new { success = true, message = "Installer uploaded successfully.", installerFilePath = filePath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Installer upload failed.", error = ex.Message });
            }
        }

        // POST: api/GamesInfo/{id}/upload-cover
        [HttpPost("{id}/upload-cover")]
        public async Task<IActionResult> UploadCoverImage(int id, IFormFile coverImage)
        {
            if (coverImage == null || coverImage.Length == 0)
                return BadRequest(new { success = false, message = "Cover image is required." });

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound(new { success = false, message = "Game not found." });

            try
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

                // Manual mapping
                var editableDto = new GamesInfoDTO
                {
                    ID = existing.ID,
                    Title = existing.Title,
                    Description = existing.Description,
                    Price = existing.Price,
                    CoverImagePath = uploadResult.SecureUrl.ToString(), // update only this
                    InstallerFilePath = existing.InstallerFilePath,
                    Status = existing.Status,
                    IsActive = existing.IsActive,
                };

                await _repository.UpdateAsync(editableDto);

                return Ok(new { success = true, message = "Cover image uploaded successfully.", coverImagePath = editableDto.CoverImagePath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Cover image upload failed.", error = ex.Message });
            }
        }

    }
}
