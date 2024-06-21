using Graduation_Project.DTO.SparePartsDto;

namespace Graduation_Project.Services
{
    public interface ISparePartsRepository
    {
        void AddSparePart(SparePartsDto part);
        List<SparePartsDto> GetSpareParts();

    }
}
