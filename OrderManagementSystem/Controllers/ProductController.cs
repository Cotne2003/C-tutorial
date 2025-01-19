using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Data.Entities;
using OrderManagementSystem.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrderManagementSystem.Controllers
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
        public async Task<List<Product>> GetAll()
        {
            return await _productService.GetAll();
        }

        [HttpGet("Id")]
        public async Task<Product> GetById(int id)
        {
            return await _productService.GetById(id);
        }

        [HttpPut]
        public async Task<bool> Update(Product product)
        {
            return await _productService.UpdateProduct(product);
        }
    }
}
