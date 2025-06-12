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
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        //GET: admin/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityUser>>> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }

        //GET: admin/user/{id}
        [HttpGet("id/{id}")]
        public async Task<ActionResult<IdentityUser>> GetUserByID(string id)
        {
            Console.WriteLine($"GetUserByID called with: {id}");

            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("ID is required!");
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        //GET admin/user/{name}
        [HttpGet("name/{name}")]
        public async Task<ActionResult<IdentityUser>> GetUserByName(string name)
        {
            Console.WriteLine($"GetUserByName called with: {name}");
            var user = await _userManager.FindByNameAsync(name);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return NotFound();
            }
            Console.WriteLine("User found.");
            return Ok(user);
        }

        //GET admin/user/{email}
        [HttpGet("email/{email}")]
        public async Task<ActionResult<IdentityUser>> GetUserByEmail(string email)
        {

            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email is required!");
            }

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        //GET admin/user/{phone}
        [HttpGet("phone/{phone}")]
        public async Task<ActionResult<IdentityUser>> GetUserByPhone(string phone)
        {

            if (string.IsNullOrEmpty(phone))
            {
                return BadRequest("Phone number is required!");
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phone);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        //POST: admin/user 
        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserDTO dto)
        {
            var user = new IdentityUser
            {
                UserName = dto.Username,
                Email = dto.Email,
                PhoneNumber = dto.Phone
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            if (!string.IsNullOrEmpty(dto.Role))
                await _userManager.AddToRoleAsync(user, dto.Role);

            return CreatedAtAction(nameof(GetUserByID), new { id = user.Id }, user);
        }

        //PUT: admin/user/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(string id, [FromBody] UserUpdateDTO dto)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            // Update username
            user.UserName = dto.Username ?? user.UserName;

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
                return BadRequest(updateResult.Errors);

            // Update role (remove current and add new one)
            if (!string.IsNullOrEmpty(dto.Role))
            {
                var currentRoles = await _userManager.GetRolesAsync(user);
                var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!removeResult.Succeeded)
                    return BadRequest(removeResult.Errors);

                var addResult = await _userManager.AddToRoleAsync(user, dto.Role);
                if (!addResult.Succeeded)
                    return BadRequest(addResult.Errors);
            }

            return NoContent();
        }

        // DELETE: admin/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return NoContent();
        }
    }
}
