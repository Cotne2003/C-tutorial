using Microsoft.EntityFrameworkCore;
using RentCar.Models.Entities;

namespace RentCar.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Car> cars { get; set; }
    }
}
