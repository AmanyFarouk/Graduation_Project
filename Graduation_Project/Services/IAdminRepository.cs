using Graduation_Project.DTO.AdminDto;
using Graduation_Project.DTO.LogInDto;
using Microsoft.AspNetCore.Identity;

namespace Graduation_Project.Services
{
    public interface IAdminRepository
    {
        void Add(AdminDto _admin);
        //Task<object> LogIn(LogInUserDto _user);
    }
}
