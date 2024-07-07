using Graduation_Project.DTO.ClientDto;
using Graduation_Project.DTO.LogInDto;
using Graduation_Project.DTO.PasswordDto;
using Microsoft.AspNetCore.Identity;

namespace Graduation_Project.Services
{
    public interface IClientRepository
    {
        Task<IdentityResult> Register(ClientRegisterDTO client);
        void Edit(ClientEditProfileDto _client);
        Task<object> LogIn(LogInUserDto _user);
        Task<IdentityResult> ChangePassword(ChangePassword changePassword);
        public Task<string> Logout();
    }
}
