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

		[HttpPost]
		public async Task<bool> CreateProduct(Product data)
		{
			return await _productService.Create(data);
		}

		[HttpGet]
		public async Task<List<Product>> GetProducts()
		{
			return await _productService.Get();
		}

		[HttpDelete]
		public async Task<bool> DeleteProduct(int id)
		{
			return await _productService.DeleteProduct(id);
		}


		[HttpGet]
		[Route("api/[controller]/{id}")]
		public async Task<Product> GetProductById(int id)
		{
			return await _productService.GetById(id);
		}
	}
}
