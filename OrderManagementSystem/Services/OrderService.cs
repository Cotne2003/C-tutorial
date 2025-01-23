using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Data.DTOS.Order;
using OrderManagementSystem.Data.Entities;
using OrderManagementSystem.Interfaces;

namespace OrderManagementSystem.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateOrder(OrderCreateDTO orderCreateDTO)
        {
            try
            {
                List<Product> products = new List<Product>();
                if (orderCreateDTO.ProductIds.Any())
                {
                    foreach (var id in orderCreateDTO.ProductIds)
                    {
                        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
                        if (product != null)
                            products.Add(product);
                    }
                }

                var order = new Order()
                {
                    Products = products
                };

                var orderUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == orderCreateDTO.UserId);
                if (orderUser != null)
                    order.User = orderUser;

                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            // eager loading, lazy loading
            try
            {
                //var groupedOrders = _context.Orders.Include(x => x.User).Include(x => x.Products)
                //    .GroupBy(x => x.User.Id)
                //    .Select(g => new
                //    {
                //        UserId = g.Key,
                //        TotalOrders = g.Count(),
                //        TotalAmount = g.Sum(o => o.Products.Sum(x => x.Price))
                //    });
                var orderToDelete = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
                if (orderToDelete is null)
                    return false;

                _context.Orders.Remove(orderToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;       
            }

            return true;
        }

        public async Task<int> GetTotalOrders(int userId)
        {
            try
            {
                var UserOrders = await _context.Orders.Include(o => o.User).FirstOrDefaultAsync(o => o.User.Id == userId);
                return UserOrders.User.Orders.Count();
            }
            catch
            {
                throw new Exception("Something went wrong!");
            }
        }

        public async Task<decimal> GetTotalAmount(int id)
        {
            var UserOrders = await _context.Orders.Include(o => o.User).FirstOrDefaultAsync(o => o.User.Id == id);
            var TotalAmount = UserOrders.User.Orders.Sum(o => o.Products.Sum(x => x.Price));
            return TotalAmount;
        }

        public async Task<decimal> GetAverageAmount(int id)
        {
			var UserOrders = await _context.Orders.Include(o => o.User).FirstOrDefaultAsync(o => o.User.Id == id);
            var AverageAmount = (UserOrders.User.Orders.Sum(o => o.Products.Sum(x => x.Price))) / (UserOrders.User.Orders.Count());
            return AverageAmount;
		}

        public async Task<List<Order>> GetAllOrders(int userId)
        {
            var userOrders = new List<Order>();
            try
            {
                userOrders = await _context.Orders.Include(x => x.User).Include(x => x.Products).Where(x => x.User.Id == userId).ToListAsync();
                return userOrders;
            }
            catch (Exception)
            {
                return userOrders;
            }
        }

        public async Task<Order> GetOrderById(int id)
        {
            var order = await _context
                .Orders
                .Include(x => x.User)
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == id);
            return order;
        }

        public async Task<bool> UpdateOrder(OrderUpdateDTO orderUpdateDTO)
        {
            var existingOrder = await _context.Orders.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == orderUpdateDTO.Id);
            if (existingOrder is null)
                return false;

            var products = new List<Product>();

            foreach (var id in orderUpdateDTO.ProductIds)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
                if(product != null) 
                    products.Add(product);
            }

            existingOrder.Products = products;

            _context.Orders.Update(existingOrder);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
