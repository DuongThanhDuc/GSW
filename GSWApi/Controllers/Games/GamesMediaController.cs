using BusinessModel.Model;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using GSWApi.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GSWApi.Controllers.Games
{
    [ApiController]
    [Route("api/games/{gameId}/media")]
    public class GamesMediaController : ControllerBase
    {
        private readonly IGamesMediaRepository _repo;
        private readonly Cloudinary _cloudinary;

        public GamesMediaController(IGamesMediaRepository repo, IOptions<CloudinarySettings> settings)
        {
            if (repo == null)
                throw new ArgumentNullException(nameof(repo));
            if (settings == null || settings.Value == null)
                throw new ArgumentNullException(nameof(settings));

            _repo = repo;

            var account = new Account(
                settings.Value.CloudName ?? throw new ArgumentNullException(nameof(settings.Value.CloudName)),
                settings.Value.ApiKey ?? throw new ArgumentNullException(nameof(settings.Value.ApiKey)),
                settings.Value.ApiSecret ?? throw new ArgumentNullException(nameof(settings.Value.ApiSecret))
            );

            _cloudinary = new Cloudinary(account);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadMediaToGame(int gameId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { success = false, message = "No file provided." });

            var extension = Path.GetExtension(file.FileName)?.ToLower();
            if (string.IsNullOrEmpty(extension))
                return BadRequest(new { success = false, message = "File has no extension." });

            var mediaType = extension switch
            {
                ".jpg" or ".jpeg" or ".png" or ".gif" => "image",
                ".mp4" or ".avi" or ".mov" or ".webm" => "video",
                _ => "unknown"
            };

            if (mediaType == "unknown")
                return BadRequest(new { success = false, message = "Unsupported file type." });

            if (_cloudinary == null)
                return StatusCode(500, new { success = false, message = "Cloudinary service not initialized." });

            UploadResult uploadResult;

            if (mediaType == "image")
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, file.OpenReadStream()),
                    Folder = $"games/{gameId}/media"
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            else // video
            {
                var uploadParams = new VideoUploadParams
                {
                    File = new FileDescription(file.FileName, file.OpenReadStream()),
                    Folder = $"games/{gameId}/media"
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            if (uploadResult == null || uploadResult.SecureUrl == null)
            {
                return StatusCode(500, new { success = false, message = "Upload failed, no result returned." });
            }

            if (uploadResult.Error != null)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = $"Cloudinary Error: {uploadResult.Error.Message}"
                });
            }

            var mediaDto = new GamesMediaDTO
            {
                GameID = gameId,
                MediaURL = uploadResult.SecureUrl.ToString(),
                MediaType = mediaType
            };

            if (_repo == null)
                return StatusCode(500, new { success = false, message = "Repository not available." });

            _repo.AddMediaToGame(gameId, mediaDto);

            return Ok(new
            {
                success = true,
                message = "Media uploaded and saved successfully.",
                data = new
                {
                    mediaDto.MediaURL,
                    mediaDto.MediaType
                }
            });
        }

        [HttpDelete("delete/by-id/{mediaId}")]
        public IActionResult DeleteMediaById(int gameId, int mediaId)
        {
            if (_repo == null)
                return StatusCode(500, new { success = false, message = "Repository not available." });

            var media = _repo.GetMediaById(mediaId);
            if (media == null || media.GameID != gameId)
                return NotFound("Media not found for this game.");

            _repo.DeleteMediaFromGame(gameId, mediaId);
            return Ok(new { message = "Deleted media from database only." });
        }
    }
}
