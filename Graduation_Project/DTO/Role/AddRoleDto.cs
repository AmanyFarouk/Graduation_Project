using System.ComponentModel.DataAnnotations;

namespace Graduation_Project.DTO.Role
{
    public class AddRoleDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
