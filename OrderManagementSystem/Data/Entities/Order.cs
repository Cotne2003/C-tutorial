namespace OrderManagementSystem.Data.Entities
{
    public class Order : BaseClass
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public User User { get; set; }
    }
}
