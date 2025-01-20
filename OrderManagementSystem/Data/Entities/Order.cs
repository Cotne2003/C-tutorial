namespace OrderManagementSystem.Data.Entities
{
    public class Order : BaseClass
    {
        public int Id { get; set; }
        public List<int> Products { get; set; } = new List<int>();
        public User User { get; set; }
    }
}
