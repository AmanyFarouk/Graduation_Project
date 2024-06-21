using Graduation_Project.DTO.WorkerDto;

namespace Graduation_Project.Services
{
    public interface IWorkerRepository
    {
        void Add(AddWorkerDto workerDto);
        void Edit(int id , EditWorkerDto workerDto);
        List<EditWorkerDto> GetAll();
    }
}
