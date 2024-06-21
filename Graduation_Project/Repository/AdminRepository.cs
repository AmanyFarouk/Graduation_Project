using AutoMapper;
using Graduation_Project.DTO.AdminDto;
using Graduation_Project.Models;
using Graduation_Project.Services;

namespace Graduation_Project.Repository
{
    public class AdminRepository:IAdminRepository
    {
        private readonly Context context;
        private readonly IMapper _mapper;
        public AdminRepository(Context context,IMapper _mapper)
        {
            this.context =context ;
            this._mapper = _mapper ;
        }
        public void Add(AdminDto _admin) 
        { 
            //Admin admin = new Admin();
            //admin.ID = _admin.Id;
            //admin.Name = _admin.Name;
            //admin.Phone = _admin.Phone;
            //admin.Email = _admin.Email;
            //admin.Password = _admin.Password;
            Admin admin = _mapper.Map<Admin>(_admin);
            context.Admins.Add(admin);
            context.SaveChanges();
        }


    }
}
