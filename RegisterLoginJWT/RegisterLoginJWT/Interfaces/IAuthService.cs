using RegisterLoginJWT.Models;
using RegisterLoginJWT.Models.DTOS;

namespace RegisterLoginJWT.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegisterDTO dto);
        Task<ServiceResponse<string>> Login(UserLoginDTO dto);
    }
}
