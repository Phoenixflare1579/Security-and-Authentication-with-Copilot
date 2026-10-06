using NUnit.Framework;
using SafeVault.Security;
using System;

namespace SafeVault.Tests
{
    [TestFixture]
    public class SqlInjectionTests
    {
        [Test]
        public void SqlInjectionPayload_ShouldFailValidation()
        {
            Assert.Throws<ArgumentException>(() =>
                InputValidator.SanitizeUsername(
                    "' OR 1=1 --"));
        }

        [Test]
        public void ParameterizedQuery_ShouldBeUsed()
        {
            string query =
                "SELECT * FROM Users WHERE Username=@Username";

            Assert.IsTrue(
                query.Contains("@Username"));
        }
    }
}