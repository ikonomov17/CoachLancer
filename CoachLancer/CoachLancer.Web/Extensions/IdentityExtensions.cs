using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace CoachLancer.Web.Extensions
{
    public static class IdentityExtensions
    {
        public static IEnumerable<string> GetRoles(this IIdentity identity)
        {
            var userIdentity = (ClaimsIdentity)identity;
            var claims = userIdentity.Claims;
            var roleClaimType = userIdentity.RoleClaimType;
            var roles = claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(r => r.Value)
                .ToList();
            return roles;
        }
    }
}
