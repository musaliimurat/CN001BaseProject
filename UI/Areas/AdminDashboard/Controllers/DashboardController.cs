using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.AdminDashboard.Controllers
{
    [Area("AdminDashboard")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
