using NUnit.Framework;
using SafeVault.Controllers;
using SafeVault.Models;
using SafeVault.Security;
using System;

namespace SafeVault.Tests
{
    [TestFixture]
    public class AdminControllerTests
    {
        [Test]
        public void AdminUser_ShouldAccessDashboard()
        {
            var controller =
                new AdminController();

            var user =
                new User
                {
                    Role = Roles.Admin
                };

            string result =
                controller.AdminDashboard(user);

            Assert.AreEqual(
                "Welcome to Admin Dashboard",
                result);
        }

        [Test]
        public void StandardUser_ShouldBeRejected()
        {
            var controller =
                new AdminController();

            var user =
                new User
                {
                    Role = Roles.User
                };

            Assert.Throws<UnauthorizedAccessException>(
                () => controller.AdminDashboard(user));
        }
    }
}