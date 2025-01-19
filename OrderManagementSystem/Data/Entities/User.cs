namespace OrderManagementSystem.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public List<UserProfile> UserProfile { get; set; }
        public List<Order> Orders { get; set; }
    }
}
