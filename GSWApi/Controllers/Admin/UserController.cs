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
            var users = await _userManager.Users
                .Select(u => new { u.Id, u.UserName, u.Email, u.PhoneNumber })
                .ToListAsync();

            return Ok(new { success = true, data = users });
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

            return Ok(new { success = true, data = new[] { new { user.Id, user.UserName, user.Email, user.PhoneNumber } } });
        }

        // GET: admin/user/name/{name}
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            if (user == null)
                return NotFound(new { success = false, message = "User not found." });

            return Ok(new { success = true, data = new[] { new { user.Id, user.UserName, user.Email, user.PhoneNumber } } });
        }

        // GET: admin/user/email/{email}
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return BadRequest(new { success = false, message = "Email is required!" });

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return NotFound(new { success = false, message = "User not found." });

            return Ok(new { success = true, data = new[] { new { user.Id, user.UserName, user.Email, user.PhoneNumber } } });
        }

        // GET: admin/user/phone/{phone}
        [HttpGet("phone/{phone}")]
        public async Task<IActionResult> GetUserByPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return BadRequest(new { success = false, message = "Phone is required!" });

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phone);
            if (user == null)
                return NotFound(new { success = false, message = "User not found." });

            return Ok(new { success = true, data = new[] { new { user.Id, user.UserName, user.Email, user.PhoneNumber } } });
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
    }
}
