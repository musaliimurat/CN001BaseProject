using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;

        [HttpGet("getAllOrders")]
        public IActionResult GetAll() 
        {
            var result = _orderService.GetAllOrders();

            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);

        }

        [HttpPost("addOrder")]
        public IActionResult Add(Order order) 
        {
            var result = _orderService.AddOrder(order);
            if (result.Success) 
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
    }
}
