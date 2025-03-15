using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RegisterLoginJWT.Interfaces;
using RegisterLoginJWT.Models;
using RegisterLoginJWT.Models.DTOS.User;
using RegisterLoginJWT.Models.Entities;
using System.Security.Cryptography;
using System.Text;

namespace RegisterLoginJWT.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<int>> CreateAsync(UserCreateDTO dto)
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

            var roles = await _context.roles.Include(x => x.Users).Where(x => dto.RoleIds.Contains(x.Id)).ToListAsync();

            user.Roles = roles;

            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            response.Data = user.Id;
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteASync(int id)
        {
            var userToDelete = await _context.users.FirstOrDefaultAsync(x => x.Id == id);

            if (userToDelete is null)
                return new ServiceResponse<bool> { Data = false, Success = false, Message = "User not found" };

            _context.users.Remove(userToDelete);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true, Message = "User deleted successfully" };
        }

        public async Task<ServiceResponse<List<UserDTO>>> GetAllAsync()
        {
            var response = new ServiceResponse<List<UserDTO>>();

            var users = await _context.users.Include(x => x.Roles).ToListAsync();
            response.Data = users.Select(x => _mapper.Map<UserDTO>(x)).ToList();
            response.Message = "Users get successfully";
            return response;
        }

        public async Task<ServiceResponse<UserDTO>> GetByIdAsync(int id)
        {
            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<UserDTO>() { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<string>> UpdateAsync(UserUpdateDTO dto)
        {
            var response = new ServiceResponse<string>();

            var userToUpdate = await _context.users.Include(x => x.Roles).FirstOrDefaultAsync(x => x.UserName.ToLower() == dto.UserName.ToLower());

            if (userToUpdate == null)
            {
                response.Data = string.Empty;
                response.Success = false;
                response.Message = "User not found";
                return response;
            }

            var roles = await _context.roles.Where(x => dto.RoleIds.Contains(x.Id)).ToListAsync();

            userToUpdate.Roles = roles;

            _context.users.Update(userToUpdate);
            await _context.SaveChangesAsync();
            response.Data = string.Empty;
            response.Message = "User updated successfully";
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
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        #endregion
    }
}
