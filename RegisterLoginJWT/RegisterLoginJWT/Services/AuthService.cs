using Microsoft.EntityFrameworkCore;
using RegisterLoginJWT.Interfaces;
using RegisterLoginJWT.Models;
using RegisterLoginJWT.Models.DTOS;
using System.Security.Cryptography;
using System.Text;

namespace RegisterLoginJWT.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<int>> Register(UserRegisterDTO dto)
        {
            var response = new ServiceResponse<int>();
            if (await UserExists(dto.UserName))
            {
                response.Success = false;
                response.Message = "User already exists";
                return response;
            }


        }
        public Task<ServiceResponse<string>> Login(UserLoginDTO dto)
        {
            throw new NotImplementedException();
        }

        #region PrivateMethods
        private async Task<bool> UserExists(string userName)
        {
            if (await _context.users.AnyAsync(x => x.UserName.ToLower() == userName.ToLower()))
                return true;
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA3_512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        #endregion
    }
}
