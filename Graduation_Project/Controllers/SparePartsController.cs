using Graduation_Project.DTO.SparePartsDto;
using Graduation_Project.Models;
using Graduation_Project.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SparePartsController : ControllerBase
    {
        private readonly ISparePartsRepository _sparePartsRepository;
        public SparePartsController(ISparePartsRepository spareParts)
        {
            _sparePartsRepository = spareParts;   
        }
        [HttpPost("AddSpareParts")]
        public IActionResult AddNewSparePart([FromForm]SparePartsDto partsDto)
        {
            if(ModelState.IsValid)
            {
               _sparePartsRepository.AddSparePart(partsDto);
                return Ok("Spare Part Added Successfully.");
            }
            return BadRequest(ModelState);
        }
        [HttpGet("ListAllSpareParts")]
        public IActionResult GetAll()
        {
            List<SparePartsDto> parts=_sparePartsRepository.GetSpareParts();
            return Ok(parts);
        }

    }
}
