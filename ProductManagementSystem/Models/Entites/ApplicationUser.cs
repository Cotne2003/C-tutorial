using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.X509Certificates;

namespace ProductManagementSystem.Models.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
