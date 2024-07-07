using AutoMapper;
using Graduation_Project.DTO.SparePartsDto;
using Graduation_Project.Models;
using Graduation_Project.Services;

namespace Graduation_Project.Repository
{
    public class SparePartsRepository:ISparePartsRepository
    {
        private readonly Context context;
        private readonly IMapper _mapper;
        public SparePartsRepository(Context context,IMapper _mapper)
        {
           this.context = context;
           this._mapper = _mapper;
        }
        public void AddSparePart(AddPartDto _part, IFormFile imageFile)
        {
           // SpareParts part=_mapper.Map<SpareParts>(_part);
            SpareParts part=new SpareParts();
            part.ID = _part.ID;
            part.Name = _part.Name;
            part.Price = _part.Price;
            part.ClientId = 2;

            //image 
            if (imageFile != null)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                part.Image = "/images/" + fileName; // Store the relative path
            }


            context.SpareParts.Add(part);

            context.SaveChanges();

        }
        public List<SparePartsDto> GetSpareParts()
        {
            List<SpareParts>parts=context.SpareParts.ToList();
            List<SparePartsDto> partsList = new List<SparePartsDto>();
            if (!parts.Any())
                return null;
            foreach(var part in parts)
            {
                SparePartsDto partDto=new SparePartsDto();
                partDto.ID = part.ID;
                partDto.Name = part.Name;
                partDto.Price = part.Price;
                partDto.Image = part.Image;
                partsList.Add(partDto);
                
            }
            return partsList;

        }

    }
}
