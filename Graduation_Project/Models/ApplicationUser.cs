using Microsoft.AspNetCore.Identity;

namespace Graduation_Project.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
