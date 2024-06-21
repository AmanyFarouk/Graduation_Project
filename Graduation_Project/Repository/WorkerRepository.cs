using AutoMapper;
using Graduation_Project.DTO.WorkerDto;
using Graduation_Project.Models;
using Graduation_Project.Services;
using System.Collections.Immutable;

namespace Graduation_Project.Repository
{
    public class WorkerRepository:IWorkerRepository
    {
        private readonly Context context;
        private readonly IMapper _mapper;
        public WorkerRepository(Context context,IMapper _mapper)
        {
            this.context = context;
            this._mapper = _mapper;
        }
        public void Add(AddWorkerDto workerDto)
        {
           // Worker worker = _mapper.Map<Worker>(workerDto);
            Worker worker=new Worker();
            //get admin id 
            string adminName=workerDto.AdminName;
           
            var adminId = context.Admins.FirstOrDefault(a=>a.Name==adminName).ID;
            //worker.AdminId = context.Admins.FirstOrDefault(a => a.Name == adminName).ID;
            worker.AdminId= adminId;
            string deptname=workerDto.DeptName;
            var deptId = context.Departments.FirstOrDefault(d => d.Name == deptname).ID;
            worker.DeptId= deptId;
            worker.Name=workerDto.Name;
            worker.Phone=workerDto.Phone;
            worker.Email=workerDto.Email;
            worker.Password=workerDto.Password;
            worker.Address=workerDto.Address;
            worker.Age=workerDto.Age;
            context.Workers.Add(worker);
            context.SaveChanges();
        }
        public void Edit(int id, EditWorkerDto workerDto)
        {
            Worker worker=context.Workers.FirstOrDefault(w=>w.ID==id);
            /////
            worker.Name = workerDto.Name;
            worker.Phone = workerDto.Phone;
            worker.Email = workerDto.Email;
            worker.Address = workerDto.Address;
            worker.Age = workerDto.Age;
            context.SaveChanges();
        }
        //get all workers
        public List<EditWorkerDto> GetAll()
        {
            var workers = context.Workers.ToList();
            List<EditWorkerDto> workersDto= new List<EditWorkerDto>();
            if (!workers.Any())
                return null;
            foreach(var worker in workers)
            {
                EditWorkerDto workerDto = new EditWorkerDto();
                workerDto.Name = worker.Name;
                workerDto.Phone = worker.Phone;
                workerDto.Email = worker.Email;
                workerDto.Address = worker.Address;
                workerDto.Age = worker.Age;
                workersDto.Add(workerDto);
            }
            return workersDto;
        }
    }
}
