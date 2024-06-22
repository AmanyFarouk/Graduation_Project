using Graduation_Project.DTO.PaymentDto;
using Graduation_Project.Models;
using Graduation_Project.Services;

namespace Graduation_Project.Repository
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly Context context;
        public PaymentRepository(Context context)
        {
            this.context = context;
        }

        //public void Add(PaymentDto payment)
        //{
        //    var clientName=payment.ClientName.Split(" ");
        //    Payment pay=new Payment();
        //    pay.ID=payment.ID;
        //    pay.Price=payment.Price;
        //    pay.WalletPassword=payment.WalletPassword;
        //    pay.ClientId = context.Clients.FirstOrDefault(c => c.FName == clientName[0] && c.LName == clientName[1]).ID;
        //    pay.Phone = payment.Phone;
        //    context.Payments.Add(pay);
        //    context.SaveChanges();

        //}
    }
}
