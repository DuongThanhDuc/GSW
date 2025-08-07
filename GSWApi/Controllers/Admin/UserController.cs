using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using System.Threading.Tasks;
using DataAccess.DTOs;
using CloudinaryDotNet;
using DataAccess.Repository.IRepository;
using CloudinaryDotNet.Actions;

namespace GSWApi.Controllers.Admin
{
    [Route("admin/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ISystemProfilePictureRepository _repo;
        private readonly Cloudinary _cloudinary;
        private readonly IStoreLibraryRepository _libraryRepo;
        private readonly IGamesInfoRepository _gamesRepo;

        public UserController(
            UserManager<IdentityUser> userManager,
            ISystemProfilePictureRepository repo,
            IStoreLibraryRepository libraryRepo,
            IGamesInfoRepository gamesRepo,
            Cloudinary cloudinary)
        {
            _userManager = userManager;
            _repo = repo;
            _cloudinary = cloudinary;
            _libraryRepo = libraryRepo;
            _gamesRepo = gamesRepo;
        }


        // GET: admin/user
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var userList = new List<object>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var profile = await _repo.GetByUserIdAsync(user.Id);
                var claims = await _userManager.GetClaimsAsync(user);
                var displayName = claims.FirstOrDefault(c => c.Type == "DisplayName")?.Value;

                userList.Add(new
                {
                    user.Id,
                    user.UserName,
                    user.Email,
                    user.PhoneNumber,
                    DisplayName = displayName,
                    Roles = roles,
                    ProfilePicture = profile?.ImageUrl
                });
            }

            return Ok(new { success = true, data = userList });
        }


        // GET: admin/user/id/{id}
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetUserByID(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest(new { success = false, message = "ID is required!" });

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { success = false, message = "User not found." });

            var roles = await _userManager.GetRolesAsync(user);
            var profile = await _repo.GetByUserIdAsync(user.Id);
            var claims = await _userManager.GetClaimsAsync(user);
            var displayName = claims.FirstOrDefault(c => c.Type == "DisplayName")?.Value;

            return Ok(new
            {
                success = true,
                data = new[]
                {
            new {
                user.Id,
                user.UserName,
                user.Email,
                user.PhoneNumber,
                DisplayName = displayName,
                Roles = roles,
                ProfilePicture = profile?.ImageUrl
            }
        }
            });
        }


        [HttpGet("search")]
        public async Task<IActionResult> GetUser([FromQuery] string by, [FromQuery] string value)
        {
            if (string.IsNullOrEmpty(by) || string.IsNullOrEmpty(value))
                return BadRequest(new { success = false, message = "Search type and value are required." });

            IdentityUser user = by.ToLower() switch
            {
                "name" => await _userManager.FindByNameAsync(value),
                "email" => await _userManager.FindByEmailAsync(value),
                "phone" => await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == value),
                _ => null
            };

            if (user == null)
                return NotFound(new { success = false, message = "User not found." });

            var roles = await _userManager.GetRolesAsync(user);
            var claims = await _userManager.GetClaimsAsync(user);
            var displayName = claims.FirstOrDefault(c => c.Type == "DisplayName")?.Value;

            return Ok(new
            {
                success = true,
                data = new[]
                {
            new {
                user.Id,
                user.UserName,
                user.Email,
                user.PhoneNumber,
                DisplayName = displayName,
                Roles = roles
            }
        }
            });
        }


        // PUT: admin/user/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserUpdateDTO dto)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { success = false, message = "User not found." });

            user.UserName = dto.Username ?? user.UserName;

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
                return BadRequest(new { success = false, errors = updateResult.Errors });

            if (!string.IsNullOrEmpty(dto.Role))
            {
                var currentRoles = await _userManager.GetRolesAsync(user);
                var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!removeResult.Succeeded)
                    return BadRequest(new { success = false, errors = removeResult.Errors });

                var addResult = await _userManager.AddToRoleAsync(user, dto.Role);
                if (!addResult.Succeeded)
                    return BadRequest(new { success = false, errors = addResult.Errors });
            }

            var updatedRoles = await _userManager.GetRolesAsync(user);
            return Ok(new
            {
                success = true,
                data = new[] {
                    new {
                        user.Id,
                        user.UserName,
                        user.Email,
                        user.PhoneNumber,
                        Roles = updatedRoles
                    }
                }
            });
        }

        // DELETE: admin/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { success = false, message = "User not found." });

            // Remove DisplayName claim
            var claims = await _userManager.GetClaimsAsync(user);
            var displayClaim = claims.FirstOrDefault(c => c.Type == "DisplayName");
            if (displayClaim != null)
            {
                await _userManager.RemoveClaimAsync(user, displayClaim);
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return BadRequest(new { success = false, errors = result.Errors });

            return Ok(new { success = true, data = new[] { new { user.Id, message = "User deleted." } } });
        }



        // POST: admin/user/lock/{id}
        [HttpPost("lock/{id}")]
        public async Task<IActionResult> LockUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { success = false, message = "User not found." });

            await _userManager.SetLockoutEnabledAsync(user, true);
            // Set lockout end date to far future (indefinite)
            await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);

            return Ok(new { success = true, message = "User has been locked." });
        }

        // POST: admin/user/unlock/{id}
        [HttpPost("unlock/{id}")]
        public async Task<IActionResult> UnlockUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { success = false, message = "User not found." });

            // Set LockoutEnd = null to unlock
            await _userManager.SetLockoutEndDateAsync(user, null);

            return Ok(new { success = true, message = "User has been unlocked." });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUserProfile(string id, [FromForm] UpdateProfileDTO dto, IFormFile? imageFile)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(new { success = false, message = "ID cannot be empty." });

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { success = false, message = "Account not found." });

            // Update user fields
            user.UserName = dto.Username ?? user.UserName;
            user.Email = dto.Email ?? user.Email;
            user.PhoneNumber = dto.PhoneNumber ?? user.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return BadRequest(new { success = false, message = "Update failed.", errors = result.Errors });

            string? uploadedImageUrl = null;

            if (imageFile != null && imageFile.Length > 0)
            {
                try
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(imageFile.FileName, imageFile.OpenReadStream()),
                        Folder = "profile_pictures",
                        PublicId = $"user_{id}",
                        Overwrite = true
                    };

                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                    if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        uploadedImageUrl = uploadResult.SecureUrl.ToString();

                        await _repo.CreateOrUpdateAsync(new SystemProfilePictureDTO
                        {
                            UserId = id,
                            ImageUrl = uploadedImageUrl
                        });
                    }
                    else
                    {
                        return BadRequest(new
                        {
                            success = false,
                            message = "Failed to upload image to Cloudinary.",
                            error = uploadResult.Error?.Message
                        });
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new
                    {
                        success = false,
                        message = "Error uploading image.",
                        error = ex.Message
                    });
                }
            }

            var roles = await _userManager.GetRolesAsync(user);
            var profilePicture = uploadedImageUrl ?? (await _repo.GetByUserIdAsync(id))?.ImageUrl;

            return Ok(new
            {
                success = true,
                data = new
                {
                    user.Id,
                    user.UserName,
                    user.Email,
                    user.PhoneNumber,
                    Roles = roles,
                    ProfilePicture = profilePicture
                }
            });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateDisplayName(string id, [FromQuery] string displayName)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound("User not found.");

            var claims = await _userManager.GetClaimsAsync(user);
            var existingClaim = claims.FirstOrDefault(c => c.Type == "DisplayName");

            if (existingClaim != null)
            {
                await _userManager.ReplaceClaimAsync(user, existingClaim, new System.Security.Claims.Claim("DisplayName", displayName));
            }
            else
            {
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("DisplayName", displayName));
            }

            return Ok("DisplayName updated.");
        }


        [HttpGet("with-library")]
        public async Task<IActionResult> GetAllUsersWithLibrary()
        {
            var users = await _userManager.Users.ToListAsync();
            var result = new List<object>();

            foreach (var user in users)
            {
                var profile = await _repo.GetByUserIdAsync(user.Id);
                var roles = await _userManager.GetRolesAsync(user);
                var userLibrary = await _libraryRepo.GetByUserIdAsync(user.Id);

                var gameList = new List<object>();
                foreach (var lib in userLibrary)
                {
                    var game = await _gamesRepo.GetByIdAsync(lib.GamesID);
                    if (game != null)
                    {
                        gameList.Add(new
                        {
                            game.ID,
                            game.Title,
                            game.Description,
                            game.Price,
                            game.Genre,
                            game.CoverImagePath,
                            game.InstallerFilePath
                        });
                    }
                }

                result.Add(new
                {
                    user.Id,
                    user.UserName,
                    user.Email,
                    user.PhoneNumber,
                    Roles = roles,
                    ProfilePicture = profile?.ImageUrl,
                    Library = gameList
                });
            }

            return Ok(new { success = true, data = result });
        }


        [HttpGet("with-library/{id}")]
        public async Task<IActionResult> GetUserWithLibrary(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { success = false, message = "User not found." });

            var profile = await _repo.GetByUserIdAsync(user.Id);
            var roles = await _userManager.GetRolesAsync(user);
            var userLibrary = await _libraryRepo.GetByUserIdAsync(user.Id);

            var gameList = new List<object>();
            foreach (var lib in userLibrary)
            {
                var game = await _gamesRepo.GetByIdAsync(lib.GamesID);
                if (game != null)
                {
                    gameList.Add(new
                    {
                        game.ID,
                        game.Title,
                        game.Description,
                        game.Price,
                        game.Genre,
                        game.CoverImagePath,
                        game.InstallerFilePath
                    });
                }
            }

            return Ok(new
            {
                success = true,
                data = new
                {
                    user.Id,
                    user.UserName,
                    user.Email,
                    user.PhoneNumber,
                    Roles = roles,
                    ProfilePicture = profile?.ImageUrl,
                    Library = gameList
                }
            });
        }
    }
}
