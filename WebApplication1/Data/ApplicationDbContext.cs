﻿using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Entities;

namespace WebApplication1.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Product> Products { get; set; }
    }
}
