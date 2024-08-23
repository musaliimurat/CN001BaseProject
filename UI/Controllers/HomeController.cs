using Business.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;
using UI.ViewModels;

namespace UI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IProductImageService _productImageService;
		public HomeController(ILogger<HomeController> logger, IProductImageService productImageService)
		{
			_logger = logger;
			_productImageService = productImageService;
		}

		public IActionResult Index()
		{
			HomeVM vm = new()
			{
				
				Products = _productImageService.GetAllProductImagesByFeatured().Data,
			};
			return View(vm);
		}
		public IActionResult Detail()
		{
			return View();
		}
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(ProductImageAddDto productImage)
		{
			try
			{
				_productImageService.AddProductImage(productImage);
				return RedirectToAction("Index");
			}
			catch (Exception)
			{

				return View();

			}
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
