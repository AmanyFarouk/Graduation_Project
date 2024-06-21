using System.ComponentModel.DataAnnotations;

namespace Graduation_Project.DTO.LogInDto
{
    public class LogInUserDto
    {
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}
