using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using GSWApi.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace GSWApi.Controllers.Games
{
    [ApiController]
    [Route("api/games/banner")]
    public class GamesBannerController : ControllerBase
    {

        private readonly IGamesBannerRepository _repo;
        private readonly Cloudinary _cloudinary;

        public GamesBannerController(
            IGamesBannerRepository repo,
            IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _repo = repo;

            var account = new Account(
                cloudinaryConfig.Value.CloudName,
                cloudinaryConfig.Value.ApiKey,
                cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(account);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(
            [FromForm] GamesBannerDTO dto,
            IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
                return BadRequest(new { success = false, message = "Image file is required." });

            // Upload to Cloudinary
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(imageFile.FileName, imageFile.OpenReadStream()),
                Folder = "games/banners"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            if (uploadResult.Error != null)
            {
                return StatusCode(500, new { success = false, message = "Image upload failed.", error = uploadResult.Error.Message });
            }

            dto.ImageUrl = uploadResult.SecureUrl.ToString();

            _repo.CreateBanner(dto);
            return Ok(new { success = true, message = "Banner created.", data = dto });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBanner(
            int id,
            [FromForm] GamesBannerDTO dto,
            IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(imageFile.FileName, imageFile.OpenReadStream()),
                    Folder = "games/banners"
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                if (uploadResult.Error != null)
                {
                    return StatusCode(500, new { success = false, message = "Image upload failed.", error = uploadResult.Error.Message });
                }

                dto.ImageUrl = uploadResult.SecureUrl.ToString();
            }

            _repo.UpdateBanner(id, dto);
            return Ok(new { success = true, message = "Banner updated.", data = dto });
        }
    }
}
