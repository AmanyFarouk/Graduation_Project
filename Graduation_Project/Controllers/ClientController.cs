﻿using Graduation_Project.DTO.ClientDto;
using Graduation_Project.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Graduation_Project.DTO.LogInDto;

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
            var result = await _clientRepository.Add(client);
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
        //forget password
    }
}
