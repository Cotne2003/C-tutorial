using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Models;
using ProductManagementSystem.Policies.Requirements;
using System.Security.Claims;

namespace ProductManagementSystem.Policies.Handlers
{
    public class FiveYearsHandler : AuthorizationHandler<FiveYearsRequirement>
    {
        private readonly ApplicationDbContext _context;

        public FiveYearsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task<Task> HandleRequirementAsync(AuthorizationHandlerContext context, FiveYearsRequirement requirement)
        {
            var yearsWorkedClaim = context.User.FindFirst("FiveYearsWorked");

            var daysWorked = 0;

            var userIdCLaim = context.User.FindFirst(ClaimTypes.NameIdentifier) ?? context.User.FindFirst("UserId");
            var user = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == userIdCLaim.Value);

            if (user != null)
            {
                daysWorked = (DateTime.Now - (user.RegistrationDate ?? DateTime.Now)).Days;
            }

            if (yearsWorkedClaim != null)
            {
                if (daysWorked >= requirement.MinimumYears * 365)
                    context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
