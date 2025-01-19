using OrderManagementSystem.Data.DTOS.Order;
using OrderManagementSystem.Data.Entities;

namespace OrderManagementSystem.Interfaces
{
    public interface IOrderService
    {
        Task<bool> CreateOrder(OrderCreateDTO orderCreateDTO);
        Task<bool> UpdateOrder(OrderUpdateDTO orderCreateDTO);
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderById(int id);
        Task<bool> DeleteOrder(int id);
    }
}
