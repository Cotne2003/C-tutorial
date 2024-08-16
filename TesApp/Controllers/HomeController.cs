using Microsoft.AspNetCore.Mvc;

namespace TesApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
