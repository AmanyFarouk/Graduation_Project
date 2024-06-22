using Graduation_Project.DTO.WorkerDto;
using Graduation_Project.Models;
using Graduation_Project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerRepository _workerRepository;
        public WorkerController(IWorkerRepository worker)
        {
                _workerRepository = worker;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("AddWorker")]
        public IActionResult AddWorker([FromForm]AddWorkerDto worker)
        {
            if(ModelState.IsValid)
            {
                _workerRepository.Add(worker);
                return Ok("Add Worker Done");
            }
            return BadRequest(ModelState);
        }
        //logIn as a worker
        //edit worker profile
        [Authorize(Roles = "Admin,Worker")]
        [HttpPut("EditWorker")]
        public IActionResult EditWorker(int id, [FromForm] EditWorkerDto worker)
        {
            if(ModelState.IsValid)
            {
                _workerRepository.Edit(id,worker);
                return Ok("Edit Worker Done");
            }
            return BadRequest(ModelState);
        }
        //get all workers
        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllWorkers")]
        public IActionResult GetAllWorkers() 
        {
            List<EditWorkerDto> workers=_workerRepository.GetAll();
            return Ok(workers);
        }
        //login
        //change password
        //forget password


    }
}
