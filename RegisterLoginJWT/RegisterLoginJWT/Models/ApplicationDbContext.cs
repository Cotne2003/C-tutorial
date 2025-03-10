using Microsoft.EntityFrameworkCore;
using RegisterLoginJWT.Models.Entities;

namespace RegisterLoginJWT.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
            
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
    }
}
