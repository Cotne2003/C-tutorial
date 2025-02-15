using System.ComponentModel.DataAnnotations;

namespace ProductManagementSystem.Models.VM.Auth
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
