using Graduation_Project.DTO.OrderDto;
using Graduation_Project.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository order)
        {
            _orderRepository = order;
        }
        //make order client
        [HttpPost("MakeOrder")]
        public IActionResult MakeOrder([FromForm] OrderClientDto orderClient)
        {
            if (ModelState.IsValid)
            {
                _orderRepository.Add(orderClient);
                return Ok("Make Order Done");
            }
            return BadRequest(ModelState);

        }
        //edit order admin  
        [HttpPut("AddOrderByAdmin")]
        public IActionResult AdminAddOrder(int id, [FromForm] OrderAdminDto orderAdmin)
        {
            if (ModelState.IsValid)
            {
                _orderRepository.Edit(id, orderAdmin);
                return Ok("Order Added");
            }
            return BadRequest(ModelState);
        }
        //get all orders
        [HttpGet("GetAllOrdersToAdmin")]
        public IActionResult GetAllOrders()
        {
            List<OrderDto> orders = _orderRepository.GetAll();
            return Ok(orders);
        }
        //get order by id
        [HttpGet("GetOrderById")]
        public IActionResult GetOrder(int id)
        {
            OrderClientDto order = _orderRepository.GetById(id);
            return Ok(order);
        }
        //get all orders by id of client
        [HttpGet("GetOrdersByClientId")]
        public IActionResult GetOrderById(int id)
        {
            List<GetAllOrdersClientDto> orders=_orderRepository.GetOrdersById(id);
            return Ok(orders);
        }
        //edit order (by client)
        [HttpPost("EditOrder")]
        public IActionResult EditOrder(int id, [FromForm] OrderClientDto order)
        {
            if(ModelState.IsValid)
            {
               _orderRepository.EditOrder(id , order);
                return Ok("Order Edited");
            }
            return BadRequest(ModelState);
        }
        //delete order (client)
        [HttpDelete("DeleteOrder")]
        public IActionResult DeleteOrder(int id)
        {
            _orderRepository.Delete(id);
            return Ok("Order Deleted Successfully.");
        }
    }
}
