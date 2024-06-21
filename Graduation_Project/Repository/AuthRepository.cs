using Graduation_Project.Services;
using Microsoft.AspNetCore.Identity;

namespace Graduation_Project.Repository
{
    public class AuthRepository:IAuthRepository
    {
        private readonly IConfiguration config;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthRepository(IConfiguration config, RoleManager<IdentityRole> roleManager)
        {
            this.config = config;
            this._roleManager = roleManager;
        }
        //public string CreateToken()
        //{

        //}
    }
}
