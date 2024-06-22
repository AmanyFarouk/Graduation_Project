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
        private readonly IPaymentRepository _payment;
        public PaymentController(IPaymentRepository _payment)
        {
            this._payment = _payment;                
        }
        [Authorize(Roles ="Client")]
        [HttpPost("MakePayment")]
        public IActionResult Payment([FromForm]PaymentDto payment)
        {
            if (_payment == null)
            {
                return BadRequest(ModelState);
            }
           // _payment.Add(payment);
            return Ok("Payment Done Successfully");
        }
    }
}
