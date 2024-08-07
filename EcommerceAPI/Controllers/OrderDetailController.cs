using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController(IOrderDetailService orderDetailService) : ControllerBase
    {

        private readonly IOrderDetailService _orderDetailService = orderDetailService;

        [HttpGet("getAllOrderDetails")]
        public IActionResult GetAll()
        {
            var result = _orderDetailService.GetAllDetailOrders();

            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);

        }

        [HttpPost("addOrderDetail")]
        public IActionResult Add(OrderDetail orderDetail)
        {
            var result = _orderDetailService.AddOrderDetail(orderDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
    }
}
