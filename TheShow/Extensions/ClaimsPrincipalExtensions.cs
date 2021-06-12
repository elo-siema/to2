using System;
using System.Linq;
using System.Security.Claims;

namespace TheShow.Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid Id(this ClaimsPrincipal claimsPrincipal)
            => Guid.Parse(claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? Guid.Empty.ToString());
    }
}
