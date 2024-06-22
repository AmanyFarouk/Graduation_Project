//using Graduation_Project.DTO.Role;
//using Graduation_Project.Models;
//using Graduation_Project.Services;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace Graduation_Project.Repository
//{
//    public class AuthRepository:IAuthRepository
//    {
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly IConfiguration config;
//        private readonly RoleManager<IdentityRole> _roleManager;
//        public AuthRepository(UserManager<ApplicationUser> _userManager, IConfiguration config, RoleManager<IdentityRole> roleManager)
//        {
//            this.config = config;
//            this._roleManager = roleManager;
//            this._userManager = _userManager;
//        }
//        public async Task<object> CreateToken(ApplicationUser user)
//        {
//            var _claims = new List<Claim>();
//            var userClaims = await _userManager.GetClaimsAsync(user);
//            _claims.Add(new Claim(ClaimTypes.Email, user.Email));
//            _claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
//            //jit ==>jwt id
//            _claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
//            //get role
//            var roles = await _userManager.GetRolesAsync(user);
//            foreach (var roleItem in roles)
//            {
//                _claims.Add(new Claim(ClaimTypes.Role, roleItem));
//            }
//            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]));
//            SigningCredentials signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
//            //create token
//            JwtSecurityToken myToken = new JwtSecurityToken(
//                issuer: config["JWT:ValidIssuer"],//url web api
//                audience: config["JWT:ValidAudiance"],//url consumer
//                claims: _claims,
//                expires: DateTime.Now.AddHours(1),
//                signingCredentials: signingCred
//                );
//            var result = new
//            {
//                DisplayName = user.FirstName + " " + user.LastName,
//                token = new JwtSecurityTokenHandler().WriteToken(myToken),
//                expiration = myToken.ValidTo
//            };
//            return result;
//        }
//        public async Task<string> AddRole(AddRoleDto roleDto)
//        {
//            var user =await _userManager.FindByEmailAsync(roleDto.Email);
//            if (user == null || !await _roleManager.RoleExistsAsync(roleDto.Role))
//                return "Invalid Email or Role";
//            if (await _userManager.IsInRoleAsync(user, roleDto.Role))
//                return "User already assigned to this role";
//            var result = await _userManager.AddToRoleAsync(user, roleDto.Role);

//            return result.Succeeded ? string.Empty : "Something went wrong";

//        }
//    }
//}
