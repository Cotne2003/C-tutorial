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
            try
            {
                Order OrderForDelete = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
                _context.Orders.Remove(OrderForDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Order>> GetAllOrders()
        {
            try
            {
                return await _context.Orders.Include(x => x.Products).Include(x => x.User).ToListAsync();
            }
            catch
            {
                throw new Exception("something wrong :(");
            }
        }

        public async Task<Order> GetOrderById(int id)
        {
            var order = await _context.Orders.Include(x => x.User).Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);
            return order;
        }

        public Task<bool> UpdateOrder(OrderUpdateDTO orderCreateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
