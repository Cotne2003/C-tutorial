using System.ComponentModel.DataAnnotations;

namespace ProductManagementSystem.Models.VM.Auth
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "აუცილებელი ველი")]
        public string Email { get; set; }

        [Required(ErrorMessage = "აუცილებელი ველი")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
