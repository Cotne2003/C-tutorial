using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementSystem.Controllers
{
    [Authorize(Policy = "TsotnesPolicy")]
    public class NameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
