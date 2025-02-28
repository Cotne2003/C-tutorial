using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Models;
using ProductManagementSystem.Policies.Requirements;
using System.Security.Claims;

namespace ProductManagementSystem.Policies.Handlers
{
    public class TsotnesPageHandler : AuthorizationHandler<TsotnesPageRequirement>
    {
        private readonly ApplicationDbContext _context;

        public TsotnesPageHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task<Task> HandleRequirementAsync(AuthorizationHandlerContext context, TsotnesPageRequirement requirement)
        {
            var nameClaimed = context.User.FindFirst("FirstNameClaim");
            if (nameClaimed != null)
            {
                var userIdCLaim = context.User.FindFirst(ClaimTypes.NameIdentifier) ?? context.User.FindFirst("UserId");
                var user = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == userIdCLaim.Value);

                if (user != null)
                {
                    if (user.FirstName == requirement.NameRequirement)
                        context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}
