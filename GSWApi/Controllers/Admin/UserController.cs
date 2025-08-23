using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using System.Threading.Tasks;
using DataAccess.DTOs;
using CloudinaryDotNet;
using DataAccess.Repository.IRepository;
using CloudinaryDotNet.Actions;
using GSWApi.Utility;

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
        private readonly EmailService _emailService;
        public UserController(
            UserManager<IdentityUser> userManager,
            ISystemProfilePictureRepository repo,
            IStoreLibraryRepository libraryRepo,
            IGamesInfoRepository gamesRepo,
            Cloudinary cloudinary,
            EmailService emailService) 
        {
            _userManager = userManager;
            _repo = repo;
            _cloudinary = cloudinary;
            _libraryRepo = libraryRepo;
            _gamesRepo = gamesRepo;
            _emailService = emailService; 
        }


        // GET: admin/user
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            if (users == null || !users.Any())
                return NotFound(new { success = false, message = "No users found." });

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
                    ProfilePicture = profile?.ImageUrl,
                    Status = GetUserStatus(user)
                });
            }

            return Ok(new { success = true, data = userList });
        }

        // GET: admin/user/id/{id}
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetUserByID(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(new { success = false, message = "ID is required!" });

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { success = false, message = "User not found." });

            var roles = await _userManager.GetRolesAsync(user);
            var profile = await _repo.GetByUserIdAsync(user.Id);
            var claims = await _userManager.GetClaimsAsync(user);
            var displayName = claims.FirstOrDefault(c => c.Type == "DisplayName")?.Value;

            var dto = new
            {
                user.Id,
                user.UserName,
                user.Email,
                user.PhoneNumber,
                DisplayName = displayName,
                Roles = roles,
                ProfilePicture = profile?.ImageUrl,
                Status = GetUserStatus(user)
            };

            return Ok(new { success = true, data = dto });
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetUser([FromQuery] string by, [FromQuery] string value)
        {
            if (string.IsNullOrWhiteSpace(by) || string.IsNullOrWhiteSpace(value))
                return BadRequest(new { success = false, message = "Search type and value are required." });

            IdentityUser? user = by.ToLower() switch
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

            var dto = new
            {
                user.Id,
                user.UserName,
                user.Email,
                user.PhoneNumber,
                DisplayName = displayName,
                Roles = roles,
                Status = GetUserStatus(user)
            };

            return Ok(new { success = true, data = dto });
        }

        // PUT: admin/user/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserUpdateDTO dto)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(new { success = false, message = "ID is required." });

            if (dto == null)
                return BadRequest(new { success = false, message = "Update data cannot be null." });

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

            var dtoResult = new
            {
                user.Id,
                user.UserName,
                user.Email,
                user.PhoneNumber,
                Roles = updatedRoles
            };

            return Ok(new { success = true, data = dtoResult });
        }

        // DELETE: admin/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(new { success = false, message = "ID is required." });

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { success = false, message = "User not found." });

            var claims = await _userManager.GetClaimsAsync(user);
            var displayClaim = claims.FirstOrDefault(c => c.Type == "DisplayName");
            if (displayClaim != null)
                await _userManager.RemoveClaimAsync(user, displayClaim);

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return BadRequest(new { success = false, errors = result.Errors });

            var dto = new { user.Id, message = "User deleted." };
            return Ok(new { success = true, data = dto });
        }

        // POST: admin/user/lock/{id}
        [HttpPost("lock/{id}")]
        public async Task<IActionResult> LockUser(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(new { success = false, message = "ID is required." });

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { success = false, message = "User not found." });

            await _userManager.SetLockoutEnabledAsync(user, true);
            await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);

            return Ok(new { success = true, message = "User has been locked." });
        }

        // POST: admin/user/unlock/{id}
        [HttpPost("unlock/{id}")]
        public async Task<IActionResult> UnlockUser(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(new { success = false, message = "ID is required." });

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { success = false, message = "User not found." });

            await _userManager.SetLockoutEndDateAsync(user, null);

            return Ok(new { success = true, message = "User has been unlocked." });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUserProfile(string id, [FromForm] UpdateProfileDTO dto, IFormFile? imageFile)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest(new { success = false, message = "ID cannot be empty." });

            if (dto == null)
                return BadRequest(new { success = false, message = "Profile data cannot be null." });

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { success = false, message = "Account not found." });

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

            var dtoResult = new
            {
                user.Id,
                user.UserName,
                user.Email,
                user.PhoneNumber,
                Roles = roles,
                ProfilePicture = profilePicture
            };

            return Ok(new { success = true, data = dtoResult });
        }

        [HttpPut("update/displayname/{id}")]
        public async Task<IActionResult> UpdateDisplayName(string id, [FromQuery] string displayName)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(displayName))
                return BadRequest(new { success = false, message = "ID and DisplayName are required." });

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { success = false, message = "User not found." });

            var claims = await _userManager.GetClaimsAsync(user);
            var existingClaim = claims.FirstOrDefault(c => c.Type == "DisplayName");

            if (existingClaim != null)
                await _userManager.ReplaceClaimAsync(user, existingClaim, new System.Security.Claims.Claim("DisplayName", displayName));
            else
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("DisplayName", displayName));

            return Ok(new { success = true, message = "DisplayName updated." });
        }


        [HttpGet("with-library")]
        public async Task<IActionResult> GetAllUsersWithLibrary()
        {
            var users = await _userManager.Users.ToListAsync();

            if (users == null || users.Count == 0)
                return NotFound(new { success = false, message = "No users found." });

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

                var userWishlist = await _gamesRepo.GetWishlistsByUserAsync(user.Id);
                var wishlistGames = new List<object>();
                foreach (var wish in userWishlist)
                {
                    var game = await _gamesRepo.GetByIdAsync(wish.WishlistGameId);
                    if (game != null)
                    {
                        wishlistGames.Add(new
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
                    Library = gameList,
                    Wishlist = wishlistGames,
                    Status = GetUserStatus(user)
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

            var userWishlist = await _gamesRepo.GetWishlistsByUserAsync(user.Id);
            var wishlistGames = new List<object>();
            foreach (var wish in userWishlist)
            {
                var game = await _gamesRepo.GetByIdAsync(wish.WishlistGameId);
                if (game != null)
                {
                    wishlistGames.Add(new
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
                    Library = gameList,
                    Wishlist = wishlistGames,
                    Status = GetUserStatus(user)
                }
            });
        }

        private static string GetUserStatus(IdentityUser user)
        {
            if (user.LockoutEnd.HasValue)
            {
                if (user.LockoutEnd.Value == DateTimeOffset.MaxValue) return "locked";
                if (user.LockoutEnd.Value > DateTimeOffset.UtcNow) return "banned";
            }
            return "active";
        }

        // POST: admin/user/ban/{id}
        [HttpPost("ban/{id}")]
        public async Task<IActionResult> BanUser(string id, [FromQuery] int days = 5)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { success = false, message = "User not found.", status = "not_found" });

            await _userManager.SetLockoutEnabledAsync(user, true);
            var unlockDate = DateTimeOffset.UtcNow.AddDays(days);
            await _userManager.SetLockoutEndDateAsync(user, unlockDate);

            if (!string.IsNullOrWhiteSpace(user.Email))
            {
                await _emailService.SendEmailAsync(
                    user.Email,
                    "Your account has been temporarily banned",
                    $"Your account has been banned for {days} days and will be unlocked on {unlockDate:yyyy-MM-dd}."
                );
            }

            var dto = new UserDTOReadonly
            {
                Id = user.Id,
                UserName = user.UserName,
                Status = GetUserStatus(user),
                LockoutEnd = unlockDate,
                Message = $"User has been banned for {days} days (until {unlockDate:yyyy-MM-dd})."
            };

            return Ok(new { success = true, data = dto });
        }

        // POST: admin/user/unban/{id}
        [HttpPost("unban/{id}")]
        public async Task<IActionResult> UnbanUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { success = false, message = "User not found.", status = "not_found" });

            await _userManager.SetLockoutEndDateAsync(user, null);

            if (!string.IsNullOrWhiteSpace(user.Email))
            {
                await _emailService.SendEmailAsync(
                    user.Email,
                    "Your account has been restored",
                    "Your account has been unbanned and is now active. You can sign in again."
                );
            }

            var dto = new UserDTOReadonly
            {
                Id = user.Id,
                UserName = user.UserName,
                Status = GetUserStatus(user),
                LockoutEnd = null,
                Message = "User has been unbanned and notified via email."
            };

            return Ok(new { success = true, data = dto });
        }

    }
}
