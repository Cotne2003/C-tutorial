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

		public async Task<bool> Create(Product request)
		{
			var product = new Product
			{
				Name = request.Name,
				Price = request.Price
			};

			await _context.Products.AddAsync(product);
			await _context.SaveChangesAsync();

			return true;
		}

		public async Task<List<Product>> Get()
		{
			return _context.Products.ToList();
		}
		public async Task<Product> GetById(int id)
		{

			return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<bool> DeleteProduct(int id)
		{
			try
			{
				var productForDelete = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
				_context.Products.Remove(productForDelete);
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
