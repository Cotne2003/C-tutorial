using WebApplication1.Data;
using WebApplication1.Data.Entities;

namespace WebApplication1.Services
{
	public class UserService
	{
		private readonly ApplicationDbContext _context;

		public UserService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<User>> Get()
		{
			return  _context.Users.ToList();
		}

		public async Task<bool> Post(User user)
		{
			var newUser = new User()
			{
				FirstName = user.FirstName,
			};

			await _context.Users.AddAsync(newUser);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
