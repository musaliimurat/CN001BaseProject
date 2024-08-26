using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using UI.ViewModels;

namespace UI.Controllers
{
    [Route("Error/{statusCode}")]
    public class ErrorController : Controller
    {
        public IActionResult Error(int statusCode)
        {
            var feature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            ErrorVM vm = new() 
            {
                StatusCode = statusCode,
                Path = feature?.OriginalPath
            };
            return View(vm);
        }
    }
}
