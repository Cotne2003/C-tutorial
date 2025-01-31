using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class ProductController : Controller
    {
        public List<ProductViewModel> Products { get; set; } = new()
        {
            new() { Id = 1, Name = "Laptop", Description = "Gaming laptop with RTX 4060", DateTime = DateTime.Now, Price = 1299.99m },
            new() { Id = 2, Name = "Smartphone", Description = "Flagship phone with OLED display", DateTime = DateTime.Now, Price = 999.99m },
            new() { Id = 3, Name = "Headphones", Description = "Noise-canceling over-ear headphones", DateTime = DateTime.Now, Price = 199.99m },
            new() { Id = 4, Name = "Mechanical Keyboard", Description = "RGB mechanical keyboard with red switches", DateTime = DateTime.Now, Price = 129.99m },
            new() { Id = 5, Name = "Gaming Mouse", Description = "Wireless gaming mouse with 16K DPI", DateTime = DateTime.Now, Price = 79.99m },
            new() { Id = 6, Name = "Monitor", Description = "27-inch 144Hz gaming monitor", DateTime = DateTime.Now, Price = 299.99m },
            new() { Id = 7, Name = "External SSD", Description = "1TB USB-C external SSD", DateTime = DateTime.Now, Price = 149.99m },
            new() { Id = 8, Name = "Smartwatch", Description = "Fitness tracking smartwatch", DateTime = DateTime.Now, Price = 249.99m },
            new() { Id = 9, Name = "Graphics Tablet", Description = "Digital drawing tablet for artists", DateTime = DateTime.Now, Price = 349.99m },
            new() { Id = 10, Name = "Bluetooth Speaker", Description = "Portable waterproof Bluetooth speaker", DateTime = DateTime.Now, Price = 99.99m }
        };
        public IActionResult Index()
        {
            return View(Products);
        }
    }
}
