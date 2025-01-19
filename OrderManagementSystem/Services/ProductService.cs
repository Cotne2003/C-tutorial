using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Data.Entities;

namespace OrderManagementSystem.Services
{
    public class ProductService
    {
        // Create, Update, Delete, Get
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
                Description = request.Description,
                Price = request.Price
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync(); 
            return true;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _context.Products.ToListAsync();

            return products;
        }

        public async Task<Product> GetById(int id)
        {
            var productToEdit = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            return productToEdit;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            try
            {
                var productToUpdate = await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);

                productToUpdate.Name = product.Name;
                productToUpdate.Description = product.Description;
                productToUpdate.Price = product.Price;

                _context.Products.Update(productToUpdate);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
