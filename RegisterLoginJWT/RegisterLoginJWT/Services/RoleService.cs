using AutoMapper;
using RegisterLoginJWT.Interfaces;
using RegisterLoginJWT.Models;
using RegisterLoginJWT.Models.DTOS.Role;
using RegisterLoginJWT.Models.Entities;

namespace RegisterLoginJWT.Services
{
    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RoleService(ApplicationDbContext context, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> CreateAsync(RoleCreateDTO dto)
        {
            var response = new ServiceResponse<string>();

            var mappedRole = _mapper.Map<Role>(dto);

            await _context.roles.AddAsync(mappedRole);
            await _context.SaveChangesAsync();

            return new ServiceResponse<string> { Data = "Role added successfully" };
        }

        public Task<ServiceResponse<bool>> DeleteASync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<RoleDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<RoleDTO>> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<string>> UpdateAsync(RoleUpdateDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
