using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Models;
using ProductManagementSystem.Models.Entites;

namespace ProductManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        [HttpGet("Product/Update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return View(product);
        }
        [HttpPost("Product/Update/{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            var ProductForUpdate = await _context.Products.FindAsync(id);
            ProductForUpdate.Name = product.Name;
            ProductForUpdate.Price = product.Price;
            ProductForUpdate.Description = product.Description;
            _context.Update(ProductForUpdate);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        [HttpGet("Product/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return View(product);
        }

        [HttpPost("Product/Delete/{id}")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var ProductToRemove = await _context.Products.FindAsync(id);
            _context.Remove(ProductToRemove);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}
