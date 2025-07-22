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
            _repo = repo;

            var account = new Account(
                settings.Value.CloudName,
                settings.Value.ApiKey,
                settings.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(account);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadMediaToGame(int gameId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file provided.");

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                Folder = $"games/{gameId}/media"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
                return StatusCode(500, $"Cloudinary Error: {uploadResult.Error.Message}");

            var mediaDto = new GamesMediaDTO
            {
                GameID = gameId,
                MediaURL = uploadResult.SecureUrl.ToString()
            };

            _repo.AddMediaToGame(gameId, mediaDto);

            return Ok(new { message = "Uploaded and saved.", url = mediaDto.MediaURL });
        }
    }
}
