using Graduation_Project.DTO.PaymentDto;
using Graduation_Project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        //private readonly IPaymentRepository _payment;
        //public PaymentController(IPaymentRepository _payment)
        //{
        //    this._payment = _payment;                
        //}
        //[Authorize(Roles ="Client")]
        //[HttpPost("MakePayment")]
        //public IActionResult Payment([FromForm]PaymentDto payment)
        //{
        //    if (_payment == null)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //   // _payment.Add(payment);
        //    return Ok("Payment Done Successfully");
        //}

        //new payment

        private readonly IPaymentRepository _PaymentRepository;

        public PaymentController(IPaymentRepository PaymentRepository)
        {
            _PaymentRepository = PaymentRepository;
        }



        [HttpGet("GetAll")]
        public IActionResult Index()
        {
            var payments = _PaymentRepository.GetPayment();
            return Ok(new { Message = "pay list", Payments = payments.Result });
        }

        [HttpPost("Makepay")]
        public IActionResult Makepay([FromBody] PaymentDto obj)
        {
            var result = _PaymentRepository.makepay(obj);
            return Ok(new { Message = "added list", Result = result.Result });
        }

        [HttpPost("ComfirmPay")]
        public IActionResult ComfirmPay([FromBody] int obj)
        {
            var result = _PaymentRepository.Comfirmpay(obj);
            return Ok(new { Message = "update list", Result = result.Result });
        }
    }
}

