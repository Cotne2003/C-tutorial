namespace WebApplication1.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public Order[] orders { get; set; }
    }
}
