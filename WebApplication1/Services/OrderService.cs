using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.DTOS;
using WebApplication1.Data.Entities;

namespace WebApplication1.Services
{
	public class OrderService
	{
		private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders.Include(x => x.User).Include(x => x.Products).ToListAsync();
        }

        public async Task<bool> CreateOrder(OrderCreateDTO orderCreateDTO)
        {
            User CustomerUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == orderCreateDTO.UserId);
            if (CustomerUser is null)
                return false;

            List<Product> products = new List<Product>();
            if (orderCreateDTO.ProductIds.Any())
            {
                foreach (int id in orderCreateDTO.ProductIds)
                {
                    var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
                    if (product != null)
                        products.Add(product);
                }
            }

            Order NewOrder = new Order()
            {
                User = CustomerUser,
                Products = products
            };
            await _context.AddAsync(NewOrder);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
