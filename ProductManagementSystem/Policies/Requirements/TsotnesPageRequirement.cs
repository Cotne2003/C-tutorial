using Microsoft.AspNetCore.Authorization;

namespace ProductManagementSystem.Policies.Requirements
{
    public class TsotnesPageRequirement : IAuthorizationRequirement
    {
        public string NameRequirement { get; set; }

        public TsotnesPageRequirement(string nameRequirement)
        {
            NameRequirement = nameRequirement;
        }
    }
}
