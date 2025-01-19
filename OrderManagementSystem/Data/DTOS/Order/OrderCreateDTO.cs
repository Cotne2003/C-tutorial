using OrderManagementSystem.Data.Entities;

namespace OrderManagementSystem.Data.DTOS.Order
{
    public class OrderCreateDTO
    {
        public List<int> ProductIds { get; set; } = new List<int>();
        public int UserId { get; set; }
    }
}
