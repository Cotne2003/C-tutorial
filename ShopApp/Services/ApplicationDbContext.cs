using Microsoft.EntityFrameworkCore;
using ShopApp.Models;

namespace ShopApp.Services
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
