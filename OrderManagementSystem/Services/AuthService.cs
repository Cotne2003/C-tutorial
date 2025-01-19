using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Data.DTOS.User;
using OrderManagementSystem.Data.Entities;

namespace OrderManagementSystem.Services
{
    public class AuthService
    {
        // register, login
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Register(UserRegisterDTO registerDTO)
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

        public async Task<bool> Login(UserLoginDTO userLoginDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userLoginDTO.Email);
            if (user is null)
                return false;

            if(userLoginDTO.Password != user.Password) 
                return false;

            return true;
        }
    }
}
