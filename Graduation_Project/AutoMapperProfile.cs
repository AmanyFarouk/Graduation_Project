using AutoMapper;
using Graduation_Project.DTO.AdminDto;
using Graduation_Project.DTO.ClientDto;
using Graduation_Project.DTO.PaymentDto;
using Graduation_Project.DTO.SparePartsDto;
using Graduation_Project.DTO.WorkerDto;
using Graduation_Project.Models;
using System.Threading.Channels;

namespace Graduation_Project
{
    public class AutoMapperProfile:Profile
    {
        //
        public AutoMapperProfile()
        {
            CreateMap<Admin, AdminDto>().ReverseMap();
            CreateMap<Client,ClientRegisterDTO>().ReverseMap();
            ////
            //CreateMap<Client,ClientEditProfileDto>().ForAllMembers(o=>o.Condition((src,dest,srcMebmber)=> srcMebmber != null));
            CreateMap<Client,ClientEditProfileDto>().ReverseMap();

            CreateMap<Worker, AddWorkerDto>().ReverseMap(); 
            CreateMap<SpareParts,SparePartsDto>().ReverseMap();
           // CreateMap<Payment,PaymentDto>().ReverseMap();
            
        }
    }
}
