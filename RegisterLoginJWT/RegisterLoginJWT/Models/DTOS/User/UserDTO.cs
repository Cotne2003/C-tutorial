using RegisterLoginJWT.Models.DTOS.Role;

namespace RegisterLoginJWT.Models.DTOS.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<RoleDTO> Roles { get; set; }
    }
}
