using ProductManagementSystem.Models.Entites;
using ProductManagementSystem.Models.VM.Order;

namespace ProductManagementSystem.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(OrderViewModel orderViewModel);
        Task<List<Order>> GetOrdersAsync();
        Task UpdateOrderAsync(int orderId, OrderViewModel orderViewModel);
        Task DeleteOrderAsync(int orderId);
    }
}
