using Microsoft.AspNetCore.Mvc;
using ShopApp.Models;
using ShopApp.Services;

namespace ShopApp.Controllers
{
	public class ProductsController : Controller
	{
		private readonly ApplicationDbContext context;

		public ProductsController(ApplicationDbContext context)
        {
			this.context = context;
		}
        public IActionResult Index()
		{
			var products = context.Products.OrderByDescending(p => p.Id).ToList();
			return View(products);
		}
        public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(ProductDto productDto)
		{

			if (!ModelState.IsValid)
			{
				return View(productDto);
			}

			return RedirectToAction("Index", "Products");
		}


    }
}
