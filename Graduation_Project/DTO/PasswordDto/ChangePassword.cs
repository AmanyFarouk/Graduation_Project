using System.ComponentModel.DataAnnotations;

namespace Graduation_Project.DTO.PasswordDto
{
    public class ChangePassword
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmNewPassword { get; set; }
    }
}
