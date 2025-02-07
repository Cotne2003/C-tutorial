using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Models;
using ProductManagementSystem.Models.VM;
using ProductManagementSystem.Services;

namespace ProductManagementSystem.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly OrderService _orderService;

        public OrderController(ApplicationDbContext context, OrderService orderService)
        {
            _context = context;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders.Include(x => x.Products).ToListAsync();
            return View(orders);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Products = await _context.Products.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel order)
        {
            await _orderService.CreateOrderAsync(order);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var order = await _context.Orders.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return RedirectToAction("Index");
        }
    }
}
