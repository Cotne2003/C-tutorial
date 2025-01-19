namespace OrderManagementSystem.Data
{
    public class BaseClass
    {
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public int? CreatorUser { get; set; }
        public int? ModifierUser { get; set; }
    }
}
