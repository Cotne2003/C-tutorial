using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Models.Entites;

namespace ProductManagementSystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
