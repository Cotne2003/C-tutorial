namespace WebApplication1.Data.Entities
{
    public class Product : Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }

    public class Base
    {
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public int? CreatorUser { get; set; }
        public int? ModifierUser { get; set; }
    }
}
