using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Mvc;

namespace GSWApi.Controllers.Games
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesDatabaseController : ControllerBase
    {
        private readonly IGamesDatabaseRepository _repository;
        private readonly IConfiguration _config;

        public GamesDatabaseController(IGamesDatabaseRepository repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadGameFile([FromForm] IFormFile file, [FromForm] int gameId)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { success = false, message = "No file uploaded." });

            try
            {
                // Setup Google Cloud Storage
                var bucketName = _config["GoogleCloud:BucketName"];
                var credentialPath = _config["GoogleCloud:CredentialFile"];

                var storageClient = await StorageClient.CreateAsync(
                    GoogleCredential.FromFile(credentialPath)
                );

                var fileName = $"{Guid.NewGuid()}_{file.FileName}";

                using (var stream = file.OpenReadStream())
                {
                    await storageClient.UploadObjectAsync(bucketName, fileName, file.ContentType, stream);
                }

                string publicUrl = $"https://storage.googleapis.com/{bucketName}/{fileName}";

                // Save URL to DB
                var dto = new GamesDatabaseDTO
                {
                    GameId = gameId,
                    GameFilePathURL = publicUrl
                };

                var saved = await _repository.CreateAsync(dto);

                return Ok(new
                {
                    success = true,
                    message = "Game file uploaded and saved.",
                    data = saved
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Upload failed.", error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _repository.GetAllAsync();
            return Ok(new { success = true, data });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null)
                return NotFound(new { success = false, message = "Entry not found." });

            return Ok(new { success = true, data = result });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repository.DeleteAsync(id);
            if (!success)
                return NotFound(new { success = false, message = "Entry not found." });

            return Ok(new { success = true, message = "Deleted successfully.", data = new { id } });
        }
    }
}
