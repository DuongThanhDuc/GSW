using DataAccess.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GSWApi.Controllers.User
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDTO dto)
        {
            if (dto == null)
                return BadRequest(new { success = false, message = "Invalid request payload." });

            var userId = User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(userId))
                return Unauthorized(new { success = false, message = "User could not be identified." });

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound(new { success = false, message = "Account not found." });

            // Update basic properties
            user.UserName = dto.Username;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;

            var updateResult = await _userManager.UpdateAsync(user);
            if (updateResult == null || !updateResult.Succeeded)
                return BadRequest(new { success = false, message = "Update failed.", errors = updateResult?.Errors });

            // Handle DisplayName claim
            var existingClaims = await _userManager.GetClaimsAsync(user);
            if (existingClaims == null)
                return StatusCode(500, new { success = false, message = "Failed to retrieve user claims." });

            var displayNameClaim = existingClaims.FirstOrDefault(c => c.Type == "DisplayName");

            if (displayNameClaim != null)
            {
                await _userManager.RemoveClaimAsync(user, displayNameClaim);
            }

            if (!string.IsNullOrWhiteSpace(dto.DisplayName))
            {
                var newClaim = new Claim("DisplayName", dto.DisplayName);
                await _userManager.AddClaimAsync(user, newClaim);
            }

            return Ok(new { success = true, data = "Profile updated successfully." });
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO dto)
        {
            if (dto == null)
                return BadRequest(new { success = false, message = "Invalid request payload." });

            var userId = User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(userId))
                return Unauthorized(new { success = false, message = "User could not be identified." });

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return Unauthorized(new { success = false, message = "Account not found." });

            var result = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);
            if (result == null || !result.Succeeded)
                return BadRequest(new { success = false, message = "Password change failed.", errors = result?.Errors });

            return Ok(new { success = true, data = "Password changed successfully." });
        }
    }
}
