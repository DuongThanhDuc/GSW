using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Microsoft.AspNetCore.Mvc;

namespace GSWApi.Controllers.Games
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesDatabaseController : ControllerBase
    {
        private readonly IGamesDatabaseRepository _repository;
        private readonly IConfiguration _config;
        private readonly DriveService _driveService;
        private readonly string _driveFolderId;

        public GamesDatabaseController(IGamesDatabaseRepository repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;

            var credential = GoogleCredential.FromFile(_config["GoogleDrive:CredentialFile"])
                .CreateScoped(DriveService.Scope.Drive);

            _driveService = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "GSW Upload"
            });

            _driveFolderId = _config["GoogleDrive:FolderId"];
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadGameFile([FromForm] IFormFile file, [FromForm] int gameId)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { success = false, message = "No file uploaded." });

            try
            {
                var fileName = $"{Guid.NewGuid()}_{file.FileName}";

                var fileMetadata = new Google.Apis.Drive.v3.Data.File
                {
                    Name = fileName,
                    Parents = new List<string> { _driveFolderId }
                };

                FilesResource.CreateMediaUpload request;
                using (var stream = file.OpenReadStream())
                {
                    request = _driveService.Files.Create(fileMetadata, stream, file.ContentType);
                    request.Fields = "id, webViewLink, webContentLink";
                    await request.UploadAsync();
                }

                var uploadedFile = request.ResponseBody;

                // Make the file public
                var permission = new Permission
                {
                    Role = "reader",
                    Type = "anyone"
                };
                await _driveService.Permissions.Create(permission, uploadedFile.Id).ExecuteAsync();

                string publicLink = uploadedFile.WebContentLink;

                // Save to DB
                var dto = new GamesDatabaseDTO
                {
                    GameId = gameId,
                    GameFilePathURL = publicLink
                };

                var saved = await _repository.CreateAsync(dto);

                return Ok(new
                {
                    success = true,
                    message = "Game uploaded to Google Drive and saved.",
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
