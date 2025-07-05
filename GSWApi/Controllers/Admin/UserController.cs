using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using System.Threading.Tasks;
using DataAccess.DTOs;

namespace GSWApi.Controllers.Admin
{
    [Route("admin/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
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
                userList.Add(new
                {
                    user.Id,
                    user.UserName,
                    user.Email,
                    user.PhoneNumber,
                    Roles = roles
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
                        Roles = roles
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
            // Set thời điểm khóa tới rất xa (vô thời hạn)
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

            // Set LockoutEnd = null để mở khóa
            await _userManager.SetLockoutEndDateAsync(user, null);

            return Ok(new { success = true, message = "User has been unlocked." });
        }

    }
}
