using Microsoft.AspNetCore.Mvc;
using RegisterLoginJWT.Interfaces;
using RegisterLoginJWT.Models;
using RegisterLoginJWT.Models.DTOS.Role;

namespace RegisterLoginJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("Test")]
        public int Test(int int1, int int2)
        {
            return int1 / int2;
        }

        [HttpGet]
        public async Task<ServiceResponse<List<RoleDTO>>> GetAllASync()
        {
            return await _roleService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<RoleDTO>> GetByIdAsync(int id)
        {
            return await _roleService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ServiceResponse<string>> CreateAsync(RoleCreateDTO dto)
        {
            return await _roleService.CreateAsync(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            return await _roleService.DeleteASync(id);
        }

        [HttpPut]
        public async Task<ServiceResponse<string>> UpdateAsync(RoleUpdateDTO dto)
        {
            return await _roleService.UpdateAsync(dto);
        }
    }
}
