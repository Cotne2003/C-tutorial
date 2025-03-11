using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public RoleService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> CreateAsync(RoleCreateDTO dto)
        {
            var mappedRole = _mapper.Map<Role>(dto);

            await _context.roles.AddAsync(mappedRole);
            await _context.SaveChangesAsync();

            return new ServiceResponse<string> { Data = "Role added successfully" };
        }

        public async Task<ServiceResponse<bool>> DeleteASync(int id)
        {
            Role roleToDelete = await _context.roles.FindAsync(id);

            _context.roles.Remove(roleToDelete);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<List<RoleDTO>>> GetAllAsync()
        {
            var roles = await _context.roles.ToListAsync();

            return new ServiceResponse<List<RoleDTO>> { Data = roles.Select(x => _mapper.Map<RoleDTO>(x)).ToList() };
        }

        public async Task<ServiceResponse<RoleDTO>> GetByIdAsync(int id)
        {
            Role role = await _context.roles.FirstOrDefaultAsync(x => x.Id == id);

            RoleDTO roleToResponse = _mapper.Map<RoleDTO>(role);

            return new ServiceResponse<RoleDTO> { Data = roleToResponse };
        }

        public async Task<ServiceResponse<string>> UpdateAsync(RoleUpdateDTO dto)
        {
            Role roleToUpdate = await _context.roles.FirstOrDefaultAsync(x => x.Id == dto.Id);

            roleToUpdate.Name = dto.Name;

            _context.Update(roleToUpdate);
            await _context.SaveChangesAsync();

            return new ServiceResponse<string> { Data = $"{dto.Name} updated successfully" };
        }
    }
}
