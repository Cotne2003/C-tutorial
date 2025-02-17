using Microsoft.EntityFrameworkCore;
using ProductManager.Models.Product;

namespace ProductManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
     
        public DbSet<Product> Products { get; set; }
    }
}
