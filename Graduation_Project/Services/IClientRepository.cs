using Graduation_Project.DTO.ClientDto;
using Graduation_Project.DTO.LogInDto;
using Microsoft.AspNetCore.Identity;

namespace Graduation_Project.Services
{
    public interface IClientRepository
    {
        Task<IdentityResult> Add(ClientRegisterDTO client);
        void Edit(int id ,ClientEditProfileDto _client);
        Task<object> LogIn(LogInUserDto _user);
    }
}
