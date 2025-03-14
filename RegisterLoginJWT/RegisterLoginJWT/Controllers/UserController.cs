using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterLoginJWT.Interfaces;
using RegisterLoginJWT.Models;
using RegisterLoginJWT.Models.DTOS.User;

namespace RegisterLoginJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ServiceResponse<List<UserDTO>>> GetAllAsync()
        {
            return await _userService.GetAllAsync();
        }
        [HttpPost]
        public async Task<ServiceResponse<int>> CreateAsync(UserCreateDTO dto)
        {
            return await _userService.CreateAsync(dto);
        }

        [HttpPut]
        public async Task<ServiceResponse<string>> UpdateAsync(UserUpdateDTO dto)
        {
            return await _userService.UpdateAsync(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            return await _userService.DeleteASync(id);
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<UserDTO>> GetByIdAsync(int id)
        {
            return await _userService.GetByIdAsync(id);
        }
    }
}
