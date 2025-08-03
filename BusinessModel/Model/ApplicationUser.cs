using Microsoft.AspNetCore.Identity;

namespace BusinessModel.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string? DisplayName { get; set; }
    }
}