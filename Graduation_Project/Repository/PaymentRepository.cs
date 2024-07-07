using AutoMapper;
using Graduation_Project.DTO.PaymentDto;
using Graduation_Project.Models;
using Graduation_Project.Services;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Project.Repository
{
    public class PaymentRepository:IPaymentRepository
    {
        //private readonly Context context;
        //public PaymentRepository(Context context)
        //{
        //    this.context = context;
        //}

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

        //new payment

        private readonly Context context;
        private readonly IMapper _mapper;

        public PaymentRepository(Context context)
        {
            this.context = context;
            this._mapper = _mapper;

        }

        public async Task<Payment> Comfirmpay(int Id)
        {
            var res = await context.Payments.FirstOrDefaultAsync(p => p.ID == Id);
            if (res == null)
            {
                return null;
            }
            res.confirm = 1;
            context.Payments.Update(res);
            var res2 = await context.SaveChangesAsync(CancellationToken.None);
            return res;
        }

        public async Task<List<Payment>> GetPayment()
        {
            var res = await context.Payments.ToListAsync();
            return res;
        }

        public async Task<Payment> makepay(PaymentDto model)
        {
            Payment pay = new Payment()
            {
                ClientId = model.ClientId,
                Phone = model.Phone,
                confirm = 0,
                ID = 0,
                Date = model.Date,
                Price = model.Price,

            };
            //model.comfirm =0
            await context.Payments.AddAsync(pay);
            var res = await context.SaveChangesAsync(CancellationToken.None);
            return pay;
        }
    }
}
