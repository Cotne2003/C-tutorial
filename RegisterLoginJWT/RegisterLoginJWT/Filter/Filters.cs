using Microsoft.AspNetCore.Mvc.Filters;

namespace RegisterLoginJWT.Filter
{
    public class Filters : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine($"Hello From Authorization Login POST ({context.ActionDescriptor.ToString()})");
        }
    }
}
