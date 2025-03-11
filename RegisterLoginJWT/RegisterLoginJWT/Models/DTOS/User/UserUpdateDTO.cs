namespace RegisterLoginJWT.Models.DTOS.User
{
    public class UserUpdateDTO
    {
        public int Id { get; set; }
        public List<int> RoleIds { get; set; }
    }
}
