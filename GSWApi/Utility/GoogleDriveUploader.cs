using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Upload;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using File = Google.Apis.Drive.v3.Data.File;


namespace GSWApi.Utility
{
    public class GoogleDriveUploader
    {
        private readonly DriveService _driveService;
        private const string FolderId = "YOUR_FOLDER_ID"; // Replace with your Google Drive folder ID

        public GoogleDriveUploader(IWebHostEnvironment env)
        {
            var credentialPath = Path.Combine(env.ContentRootPath, "credentials", "gswprototype-17dff2d28157.json");

            GoogleCredential credential;
            using (var stream = new FileStream(credentialPath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(DriveService.Scope.Drive);
            }

            _driveService = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "GSW Game Uploader"
            });
        }

        public async Task<string> UploadInstallerAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Invalid file");

            var fileMetadata = new Google.Apis.Drive.v3.Data.File
            {
                Name = file.FileName,
                Parents = new List<string> { FolderId }
            };

            using var stream = file.OpenReadStream();
            var request = _driveService.Files.Create(fileMetadata, stream, file.ContentType);
            request.Fields = "id";
            await request.UploadAsync();

            if (request.ResponseBody == null)
                throw new Exception("Google Drive upload failed");

            string fileId = request.ResponseBody.Id;

            // Make the file public
            var permission = new Permission
            {
                Type = "anyone",
                Role = "reader"
            };

            await _driveService.Permissions.Create(permission, fileId).ExecuteAsync();

            // Return public download link
            return $"https://drive.google.com/uc?id={fileId}&export=download";
        }
    }
}