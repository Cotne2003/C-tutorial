using RegisterLoginJWT.Models.DTOS.Role;
using RegisterLoginJWT.Models;

namespace RegisterLoginJWT.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<List<UserDTO>>> GetAllAsync();
        Task<ServiceResponse<UserDTO>> GetByIdAsync(int id);
        Task<ServiceResponse<string>> CreateAsync(UserCreateDTO dto);
        Task<ServiceResponse<string>> UpdateAsync(UserUpdateDTO dto);
        Task<ServiceResponse<bool>> DeleteASync(int id);
    }
}
