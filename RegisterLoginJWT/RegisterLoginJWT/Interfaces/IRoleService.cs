using RegisterLoginJWT.Models;
using RegisterLoginJWT.Models.DTOS.Role;

namespace RegisterLoginJWT.Interfaces
{
    public interface IRoleService
    {
        Task<ServiceResponse<List<RoleDTO>>> GetAllAsync();
        Task<ServiceResponse<RoleDTO>> GetByIdAsync(int id);
        Task<ServiceResponse<string>> CreateAsync(RoleCreateDTO dto);
        Task<ServiceResponse<string>> UpdateAsync(RoleUpdateDTO dto);
        Task<ServiceResponse<bool>> DeleteASync(int id);
    }
}
