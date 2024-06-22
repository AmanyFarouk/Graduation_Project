using Graduation_Project.DTO.AdminDto;
using Graduation_Project.DTO.LogInDto;
using Graduation_Project.Repository;
using Graduation_Project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository adminRepository;
        public AdminController(IAdminRepository _admin)
        {
            adminRepository = _admin;
        }
        //Add new Admin
        [Authorize(Roles ="Admin")]
        [HttpPost("AddAdmin")]//api/Admin/AddAdmin
        public IActionResult AddAdmin([FromForm] AdminDto Admin)
        {
            if(ModelState.IsValid)
            {
                //Add Admin
                adminRepository.Add(Admin);   
                return Ok("Add Admin Done");
            }
            return BadRequest(ModelState);
        }
        //[HttpPost("AdminLogIn")]
        //public async IActionResult LogIn([FromForm] LogInUserDto _userDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //var result = await _clientRepository.LogIn(userDto);
        //        var result = await adminRepository.LogIn();
        //        if (result == null)
        //            return Unauthorized();
        //        return Ok(result);
        //    }
        //    return BadRequest(ModelState);
        //}


    }
}
