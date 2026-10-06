using System.Linq;
using SafeVault.Models;

namespace SafeVault.Security
{
    public static class AuthorizationService
    {
        public static bool IsAuthorized(
            User user,
            params string[] roles)
        {
            if (user == null)
                return false;

            return roles.Contains(user.Role);
        }
    }
}