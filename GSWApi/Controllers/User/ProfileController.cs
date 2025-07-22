using DataAccess.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GSWApi.Controllers.User
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDTO dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized(new { success = false, message = "Không xác định được người dùng" });

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound(new { success = false, message = "Không tìm thấy tài khoản" });

            user.UserName = dto.Username;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return BadRequest(new { success = false, message = "Cập nhật thất bại", errors = result.Errors });

            return Ok(new { success = true, data = "Cập nhật thông tin cá nhân thành công" });
        }


        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return Unauthorized(new { success = false, message = "Không tìm thấy tài khoản!" });

            var result = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);
            if (!result.Succeeded)
                return BadRequest(new { success = false, message = "Đổi mật khẩu thất bại", errors = result.Errors });

            return Ok(new { success = true, data = "Đổi mật khẩu thành công!" });
        }

    }
}