using OrderManagementSystem.Data.DTOS.User;
using OrderManagementSystem.Data.Entities;

namespace OrderManagementSystem.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUser(UserRegisterDTO registerDTO);
        Task<bool> UpdateUser(UserUpdateDTO userUpdateDTO);
        Task<User> GetUserById(int id);
        Task<List<User>> GetAllUser();
        Task<bool> DeleteUser(int id);
    }
}
