using AutoMapper;
using Graduation_Project.DTO.ClientDto;
using Graduation_Project.DTO.LogInDto;
using Graduation_Project.Models;
using Graduation_Project.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Graduation_Project.Repository
{
    public class ClientRepository:IClientRepository
    {
        private readonly Context context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration config;
        private readonly ILogger<ClientRepository> _logger;
        public ClientRepository(Context context,IMapper _mapper,UserManager<ApplicationUser>_userManager,
            IConfiguration config, ILogger<ClientRepository> _logger)
        {
            this.context = context;
            this._mapper = _mapper;
            this._userManager = _userManager;
            this.config = config;
            this._logger = _logger;
        }
        //register

        public async Task<IdentityResult> Add(ClientRegisterDTO _client)
        {
            //Client client = _mapper.Map<Client>(_client);
            //context.Clients.Add(client);
            //context.SaveChanges();
            ApplicationUser user = new ApplicationUser
            {
                UserName = _client.Email,
                Email = _client.Email,
                PhoneNumber = _client.Phone,
                FirstName=_client.FName,
                LastName=_client.LName
            };
            IdentityResult result=await _userManager.CreateAsync(user, _client.Password);
            if(result.Succeeded)
            {
                //Client client = _mapper.Map<Client>(_client);
                Client client=new Client
                {
                FName = _client.FName,
                LName = _client.LName,
                Phone = _client.Phone,
                Email = _client.Email
                };
                context.Clients.Add(client);
                await context.SaveChangesAsync();
            }
            return result;
            
            


        }
        //try map using automapper
        public void Edit(int id, ClientEditProfileDto _client)
        {
            Client client =context.Clients.FirstOrDefault(c=>c.ID == id);

            //_mapper.Map<Client>(_client);
            //_mapper.Map(_client, client);
            //context.Clients.Update(client);
            client.FName = _client.FName;
            client.LName = _client.LName;
            client.Email = _client.Email;
            client.Phone = _client.Phone;
            context.SaveChanges();

        }
        public async Task<object> LogIn(LogInUserDto _userDto)
        {
            _logger.LogInformation("Attempting to log in user with email {Email}", _userDto.Email);
                ApplicationUser user = await _userManager.FindByEmailAsync(_userDto.Email);
            if (user != null)
            {
                bool found = await _userManager.CheckPasswordAsync(user, _userDto.Password);
                if (found)
                {
                    _logger.LogInformation("Password match for user {Email}", _userDto.Email);
                    var _claims = new List<Claim>();
                    _claims.Add(new Claim(ClaimTypes.Email, user.Email));
                    _claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    //jit ==>jwt id
                    _claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    //get role
                    var roles =await _userManager.GetRolesAsync(user);
                    foreach(var roleItem in roles)
                    {
                        _claims.Add(new Claim(ClaimTypes.Role, roleItem));
                    }
                    SecurityKey securityKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]));
                    SigningCredentials signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                    //create token
                    JwtSecurityToken myToken = new JwtSecurityToken(
                        issuer: config["JWT:ValidIssuer"],//url web api
                        audience: config["JWT:ValidAudiance"],//url consumer
                        claims: _claims,
                        expires:DateTime.Now.AddHours(1),
                        signingCredentials: signingCred
                        );
                    var result = new {
                        DisplayName = user.FirstName + " " + user.LastName,
                        token = new JwtSecurityTokenHandler().WriteToken(myToken),
                        expiration = myToken.ValidTo
                    };
                    return result;
                }
                
                else
                {
                    _logger.LogWarning("Invalid password for user {Email}", _userDto.Email);
                    return null;
                }
            }
            else
            {
                _logger.LogWarning("No user found with email {Email}", _userDto.Email);
            }
            return null;


        }

    }
}
