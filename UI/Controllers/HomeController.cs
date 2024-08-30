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
		private readonly IProductService _productService;
		public HomeController(ILogger<HomeController> logger, IProductImageService productImageService, IProductService productService)
		{
			_logger = logger;
			_productImageService = productImageService;
			_productService = productService;
		}

		public IActionResult Index()
		{
			
			HomeVM vm = new()
			{
				Products = _productImageService.GetAllProductImagesByFeatured().Data,
			};
			return View(vm);
		}
		
		
		public IActionResult Privacy()
		{
			return View();
		}

		//[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		//public IActionResult Error()
		//{
		//	return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		//}
	}
}
