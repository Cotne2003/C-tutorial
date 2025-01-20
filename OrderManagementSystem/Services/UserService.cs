using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Data.DTOS.User;
using OrderManagementSystem.Data.Entities;
using OrderManagementSystem.Interfaces;

namespace OrderManagementSystem.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateUser(UserRegisterDTO registerDTO)
        {
            try
            {
                var user = new User()
                {
                    FirstName = registerDTO.FirstName,
                    LastName = registerDTO.LastName,
                    Email = registerDTO.Email,
                    Password = registerDTO.Password
                };

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllUser()
        {
            var users = new List<User>();
            try
            {
                users = await _context.Users.ToListAsync();
                return users;
            }
            catch (Exception)
            {
                return users;
            }
        }

        public async Task<User> GetUserById(int id)
        {
            User user = default;
            try
            {
                user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception)
            {
                return default;
            }
            return user;
        }

        public Task<bool> UpdateUser(UserUpdateDTO userUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
