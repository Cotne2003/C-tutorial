namespace WebApplication1.Data.DTOS
{
	public class OrderCreateDTO
	{
		public int UserId { get; set; }
		public List<int> ProductIds { get; set; }
	}
}
