using Microsoft.EntityFrameworkCore;
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

		public async Task<List<User>> GetAllUser()
		{
			return  await _context.Users.ToListAsync();
		}

		public async Task<bool> CreateUser(User newUser)
		{
			try
			{
				var userToCreate = new User()
				{
					FirstName = newUser.FirstName
				};
				await _context.AddAsync(userToCreate);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				return false;
			}

			return true;
		}
	}
}
