using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WebApplication1.Data;
using WebApplication1.Data.Entities;

namespace WebApplication1.Services
{
    public class ProductService
	{
		private readonly ApplicationDbContext _context;

		public ProductService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<Product>> GetAllProducts()
		{
			return await _context.Products.ToListAsync();
		}

		public async Task<bool> CreateProduct(Product newProduct)
		{
			try
			{
				var productToCreate = new Product()
				{
					Name = newProduct.Name,
					Price = newProduct.Price
				};
				await _context.AddAsync(productToCreate);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				return false;
			}

			return true;
		}
	}
}
