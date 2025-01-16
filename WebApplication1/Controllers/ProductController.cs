using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Entities;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly ProductService _productService;

		public ProductController(ProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<List<Product>> Get()
		{
			return await _productService.GetAllProducts();
		}

		[HttpPost]
		public async Task<bool> CreateProduct(Product newProduct)
		{
			return await _productService.CreateProduct(newProduct);
		}
	}
}
