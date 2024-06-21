using Graduation_Project.DTO.AdminDto;
using Graduation_Project.Services;
using Microsoft.AspNetCore.Http;
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

    }
}
