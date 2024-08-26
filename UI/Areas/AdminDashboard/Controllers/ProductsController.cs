using Business.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.AdminDashboard.Controllers
{
    [Area("AdminDashboard")]
    public class ProductsController : Controller
    {
        private readonly IProductImageService _productImageService;
        private readonly IProductService _productService;

        public ProductsController(IProductService productService, IProductImageService productImageService)
        {
            _productService = productService;
            _productImageService = productImageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductImageAddDto productImage)
        {
            try
            {
                _productImageService.AddProductImage(productImage);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return NotFound();

            }
        }
    }
}
