using NUnit.Framework;
using SafeVault.Models;
using SafeVault.Security;

namespace SafeVault.Tests
{
    [TestFixture]
    public class AuthorizationTests
    {
        [Test]
        public void Admin_ShouldBeAuthorized()
        {
            var user = new User
            {
                Role = Roles.Admin
            };

            bool result =
                AuthorizationService.IsAuthorized(
                    user,
                    Roles.Admin);

            Assert.IsTrue(result);
        }

        [Test]
        public void User_ShouldNotAccessAdmin()
        {
            var user = new User
            {
                Role = Roles.User
            };

            bool result =
                AuthorizationService.IsAuthorized(
                    user,
                    Roles.Admin);

            Assert.IsFalse(result);
        }
    }
}