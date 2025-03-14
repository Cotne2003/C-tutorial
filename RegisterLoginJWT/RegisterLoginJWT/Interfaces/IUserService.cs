using RegisterLoginJWT.Models.DTOS.Role;
using RegisterLoginJWT.Models;
using RegisterLoginJWT.Models.DTOS.User;

namespace RegisterLoginJWT.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<List<UserDTO>>> GetAllAsync();
        Task<ServiceResponse<UserDTO>> GetByIdAsync(int id);
        Task<ServiceResponse<int>> CreateAsync(UserCreateDTO dto);
        Task<ServiceResponse<string>> UpdateAsync(UserUpdateDTO dto);
        Task<ServiceResponse<bool>> DeleteASync(int id);
    }
}
