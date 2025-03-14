using AutoMapper;
using RegisterLoginJWT.Models.DTOS.Role;
using RegisterLoginJWT.Models.DTOS.User;
using RegisterLoginJWT.Models.Entities;

namespace RegisterLoginJWT
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Role, RoleCreateDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
