using Microsoft.AspNetCore.Mvc;

namespace MVCProject.Controllers
{
    public class DateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
