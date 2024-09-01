using Business.Abstract;
using Business.Concrete;
using Core.Helpers.IoC;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    //AOP
    [ApiController]
    public class ProductController : ControllerBase
    {
      private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetProducts() 
        {
            var result = _productService.GetAllProduct();
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }

        [HttpGet("GetAllProductsByCategory")]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            var result = _productService.GetAllProductByCategory(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }

        [HttpGet("getProduct")]
        public IActionResult Get(int id)
        {
          var result = _productService.GetProduct(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }

        [HttpPost("addProduct")]
        public IActionResult Add(Product product) 
        {
            var result = _productService.Add(product);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("deleteProduct")]
        public IActionResult Delete(int id) 
        {
           var result =  _productService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
    }
}
