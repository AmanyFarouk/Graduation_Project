using Graduation_Project.DTO.SparePartsDto;

namespace Graduation_Project.Services
{
    public interface ISparePartsRepository
    {
        void AddSparePart(AddPartDto part, IFormFile imageFile);
        List<SparePartsDto> GetSpareParts();

    }
}
