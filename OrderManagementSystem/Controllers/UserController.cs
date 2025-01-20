using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Data.DTOS.User;
using OrderManagementSystem.Data.Entities;
using OrderManagementSystem.Interfaces;
using OrderManagementSystem.Services;

namespace OrderManagementSystem.Controllers
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

        [HttpPost]
        public async Task<bool> CreateUser(UserRegisterDTO dto)
        {
            return await _userService.CreateUser(dto);
        }

        [HttpGet]
        public async Task<List<User>> GetAll()
        {
            return await _userService.GetAllUser();
        }

        [HttpGet("Id")]
        public async Task<User> GetById(int id)
        {
            return await _userService.GetUserById(id);
        }

        [HttpPut]
        public async Task<bool> Update(UserUpdateDTO dto)
        {
            return await _userService.UpdateUser(dto);
        }

    }
}
