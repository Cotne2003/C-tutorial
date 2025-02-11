using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Interfaces;
using ProductManagementSystem.Models;
using ProductManagementSystem.Models.Entites;
using ProductManagementSystem.Models.VM;

namespace ProductManagementSystem.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IOrderService _orderService;

        public OrderController(ApplicationDbContext context, IOrderService orderService)
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
            if(order == null) 
                return NotFound();
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet("Order/Edit/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Products = await _context.Products.ToListAsync();
            var order = await _context.Orders.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);
            return View(order);
        }

        [HttpPost("Order/Edit/{id}")]
        public async Task<IActionResult> UpdateConfirmed(int id, int[] ProductsIds)
        {
            var orderToUpdate = await _context.Orders.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);
            orderToUpdate.Products.Clear();
            var selectedProducts = await _context.Products.Where(p => ProductsIds.Contains(p.Id)).ToListAsync();

            orderToUpdate.Products.AddRange(selectedProducts);

            _context.Orders.Update(orderToUpdate);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
