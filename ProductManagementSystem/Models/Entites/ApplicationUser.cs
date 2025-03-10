﻿using Microsoft.AspNetCore.Identity;

namespace ProductManagementSystem.Models.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? RegistrationDate { get; set; } = DateTime.Now;
    }
}
