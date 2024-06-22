using Graduation_Project.DTO.ClientDto;
using Graduation_Project.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Graduation_Project.DTO.LogInDto;
using Microsoft.AspNetCore.Authorization;
using Graduation_Project.DTO.PasswordDto;

namespace Graduation_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository _client)
        {
            _clientRepository = _client;
        }

        //register 
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] ClientRegisterDTO client)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _clientRepository.Register(client);
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(" ", error.Description);
                }
                return BadRequest(ModelState);
            }
            return Ok("Account Added Successfully");
            

        }

        //login
        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromForm]LogInUserDto userDto)
        {
            if(ModelState.IsValid)
            {
                //await 
                var result =await _clientRepository.LogIn(userDto);
                if (result == null)
                    return Unauthorized();
                return Ok(result);
            }
            return BadRequest(ModelState);  
        }
        //edit profile
        [Authorize(Roles = "Client")]
        [HttpPut("Edit_Profile")]
        public IActionResult Edit(int id,[FromForm]ClientEditProfileDto client)
        {
            if(ModelState.IsValid)
            {
                _clientRepository.Edit(id,client);
                return Ok("Profile Updated");
            }
            return BadRequest(ModelState);
        }
        //change password
        [Authorize(Roles ="Client")]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromForm] ChangePassword _user)
        {
            var result =await _clientRepository.ChangePassword(_user);
            if (result.Succeeded)
            {

                return Ok("Password  Change Succeeded");
            }
            else
            {
                var Errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    Errors += $"{error.Description}  +  ";
                }
                return BadRequest(Errors);
            }
            return Unauthorized();
        }
        //forget password

        //LogOut
        [Authorize]
        [HttpPost("LogOut")]
        [Authorize(Roles ="Client")]
        public async Task<IActionResult> LogOut()
        {
            var result = await _clientRepository.Logout();
            if (result == "User Logged Out Successfully")
                return Ok(result);
            return BadRequest(result);
        }
    }
}
