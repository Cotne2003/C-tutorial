namespace RegisterLoginJWT.Models.DTOS.User
{
    public class UserUpdateDTO
    {
        public string UserName { get; set; }
        public List<int> RoleIds { get; set; }
    }
}
