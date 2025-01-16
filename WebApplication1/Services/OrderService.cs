using WebApplication1.Data;
using WebApplication1.Data.Entities;

namespace WebApplication1.Services
{
	public class OrderService
	{
		private readonly ApplicationDbContext _cotnext;
        public OrderService(ApplicationDbContext context)
        {
            _cotnext = context;
        }

        public async Task<bool> CreateOrder(User user, Order newOrder)
        {
            User Customer = new User()
            {
                FirstName = user.FirstName,
            };
            return true;
        }
    }
}
