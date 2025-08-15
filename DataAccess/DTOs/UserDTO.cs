using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Role { get; set; } = null!;

    }

    public class UserUpdateDTO
    {
        public string Username { get; set; } = null!;
        public string? Role { get; set; } = null!;

    }
    
    public class UserDTOReadonly
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Status { get; set; } = "active"; // active|banned|locked
        public DateTimeOffset? LockoutEnd { get; set; }
        public string Message { get; set; } = null!;
    }

}
