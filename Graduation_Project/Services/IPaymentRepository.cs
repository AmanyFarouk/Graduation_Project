using Graduation_Project.DTO.PaymentDto;
using Graduation_Project.Models;

namespace Graduation_Project.Services
{
    public interface IPaymentRepository
    {
        //void Add(PaymentDto payment);

        //new payment
        Task<Payment> makepay(PaymentDto model);
        Task<Payment> Comfirmpay(int Id);

        Task<List<Payment>> GetPayment();
    }
}
