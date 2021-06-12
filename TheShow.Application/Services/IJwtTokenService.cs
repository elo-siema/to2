using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TheShow.Application.Services.Model;
using TheShow.Domain.User;

namespace TheShow.Application.Services
{
    public interface IJwtTokenService
    {
        Task<UserToken> GenerateTokenForUser(User user, IEnumerable<string> userRoles);
        ClaimsPrincipal GetPrincipalFromToken(string token);
        bool ValidateToken(string token);
    }
}