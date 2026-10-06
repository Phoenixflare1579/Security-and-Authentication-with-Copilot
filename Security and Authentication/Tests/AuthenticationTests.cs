using NUnit.Framework;
using SafeVault.Security;

namespace SafeVault.Tests
{
    [TestFixture]
    public class AuthenticationTests
    {
        [Test]
        public void CorrectPassword_ShouldAuthenticate()
        {
            string password = "SecurePassword123!";

            string hash =
                PasswordService.HashPassword(password);

            bool result =
                PasswordService.VerifyPassword(
                    password,
                    hash);

            Assert.IsTrue(result);
        }

        [Test]
        public void WrongPassword_ShouldFail()
        {
            string hash =
                PasswordService.HashPassword(
                    "CorrectPassword");

            bool result =
                PasswordService.VerifyPassword(
                    "WrongPassword",
                    hash);

            Assert.IsFalse(result);
        }
    }
}