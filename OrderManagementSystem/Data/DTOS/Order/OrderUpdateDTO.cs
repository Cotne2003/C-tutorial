using OrderManagementSystem.Data.Entities;

namespace OrderManagementSystem.Data.DTOS.Order
{
    public class OrderUpdateDTO
    {
        public int Id { get; set; }
        public List<int> ProductIds { get; set; }
    }
}