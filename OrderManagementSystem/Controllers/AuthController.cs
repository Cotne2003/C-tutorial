using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Data.DTOS.User;
using OrderManagementSystem.Services;

namespace OrderManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<bool> Register(UserRegisterDTO registerDTO)
        {
            return await _authService.Register(registerDTO);
        }

        [HttpPost("Login")]
        public async Task<bool> Login(UserLoginDTO loginDTO)
        {
            return await _authService.Login(loginDTO);
        }
    }
}
