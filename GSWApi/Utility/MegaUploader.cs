using Microsoft.Extensions.Options;
using CG.Web.MegaApiClient;

namespace GSWApi.Utility
{
    public class MegaSettings
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FolderName { get; set; } // Optional: Name of the folder in MEGA
    }

    public class MegaUploader : IDisposable
    {
        private readonly MegaApiClient _client;

        public MegaUploader(IOptions<MegaSettings> settings)
        {
            var config = settings.Value;
            _client = new MegaApiClient();
            _client.Login(config.Email, config.Password);
        }

        /// <summary>
        /// Uploads an IFormFile directly to a MEGA folder.
        /// </summary>
        public async Task<string> UploadInstallerAsync(IFormFile file, string folderName = null)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty or null");

            // Keep the original file name & extension
            var originalFileName = Path.GetFileName(file.FileName);
            var tempFilePath = Path.Combine(Path.GetTempPath(), originalFileName);

            using (var stream = new FileStream(tempFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var nodes = _client.GetNodes();
            INode parentFolder;

            if (!string.IsNullOrEmpty(folderName))
            {
                parentFolder = nodes.FirstOrDefault(n =>
                    n.Type == NodeType.Directory &&
                    string.Equals(n.Name, folderName, StringComparison.OrdinalIgnoreCase));
                if (parentFolder == null)
                    throw new Exception($"Folder '{folderName}' not found in MEGA.");
            }
            else
            {
                parentFolder = nodes.First(n => n.Type == NodeType.Root);
            }

            // Upload file to MEGA with original filename & extension
            INode uploadedNode = await Task.Run(() => _client.UploadFile(tempFilePath, parentFolder));

            // Clean up temp file after upload
            File.Delete(tempFilePath);

            // Return public link
            Uri link = _client.GetDownloadLink(uploadedNode);
            return link.ToString();
        }


        public void Dispose()
        {
            _client.Logout();
        }
    }
}
