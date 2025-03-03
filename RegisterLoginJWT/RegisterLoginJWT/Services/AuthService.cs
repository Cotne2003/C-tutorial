using Microsoft.EntityFrameworkCore;
using RegisterLoginJWT.Interfaces;
using RegisterLoginJWT.Models;
using RegisterLoginJWT.Models.DTOS;
using RegisterLoginJWT.Models.Entities;
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

            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                UserName = dto.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            response.Data = user.Id;
            return response;
        }
        public async Task<ServiceResponse<string>> Login(UserLoginDTO dto)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.users.FirstOrDefaultAsync(x => x.UserName.ToLower() == dto.UserName.ToLower());

            if (user is null)
            {
                response.Success = false;
                response.Message = "User not found";
                return response;
            }

            if (!VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "User password is incorrect";
                return response;
            }

            response.Data = user.UserName;
            response.Message = "User logged in successfully";
            return response;

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
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(storedHash);
            }
        }
        #endregion
    }
}
