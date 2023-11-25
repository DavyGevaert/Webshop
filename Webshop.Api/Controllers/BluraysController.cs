using Microsoft.AspNetCore.Mvc;

namespace Webshop.Api.Controllers
{
    public class BluraysController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
