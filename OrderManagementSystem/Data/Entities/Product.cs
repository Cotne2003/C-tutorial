using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.Data.Entities
{
    public class Product : BaseClass
    {
        public int Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(2500)]
        public string? Description { get; set; }

        public decimal Price { get; set; }

        public List<Order> Orders { get; set; }
    }
}
