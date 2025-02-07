using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Models;
using ProductManagementSystem.Models.Entites;
using ProductManagementSystem.Models.VM;

namespace ProductManagementSystem.Services
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateOrderAsync(OrderViewModel orderViewModel)
        {
            var order = new Order()
            {
                Products = new List<Product>()
            };

            foreach (var productId in orderViewModel.ProductIds)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
                if(product != null) 
                    order.Products.Add(product);
            }

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var oderToDelete = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);

            _context.Orders.Remove(oderToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
