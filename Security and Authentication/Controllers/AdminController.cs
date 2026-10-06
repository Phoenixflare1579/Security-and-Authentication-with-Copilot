using System;
using SafeVault.Models;
using SafeVault.Security;

namespace SafeVault.Controllers
{
    public class AdminController
    {
        public string AdminDashboard(User currentUser)
        {
            bool authorized =
                AuthorizationService.IsAuthorized(
                    currentUser,
                    Roles.Admin);

            if (!authorized)
                throw new UnauthorizedAccessException(
                    "Access denied.");

            return "Welcome to Admin Dashboard";
        }
    }
}