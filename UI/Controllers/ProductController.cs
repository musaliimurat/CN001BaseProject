using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using UI.ViewModels;

namespace UI.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductImageService _productImageService;
		private readonly IProductService _productService;

		public ProductController(IProductService productService, IProductImageService productImageService)
		{
			_productService = productService;
			_productImageService = productImageService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Detail(int id)
		{
			ProductVM vm = new()
			{
				ProductGetById = _productService.GetProduct(id).Data,
				ProductImageGetById = _productImageService.GetProductImageById(id).Data,
			};
			if (vm.ProductGetById != null)
			{
				return View(vm);

			}
			else return NotFound();
		}
	}
}
