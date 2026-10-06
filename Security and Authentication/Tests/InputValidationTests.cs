using NUnit.Framework;
using SafeVault.Security;
using System;

namespace SafeVault.Tests
{
    [TestFixture]
    public class InputValidationTests
    {
        [Test]
        public void ValidUsername_ShouldPass()
        {
            string result =
                InputValidator.SanitizeUsername(
                    "john_doe");

            Assert.AreEqual(
                "john_doe",
                result);
        }

        [Test]
        public void SqlInjectionAttempt_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() =>
                InputValidator.SanitizeUsername(
                    "' OR 1=1 --"));
        }

        [Test]
        public void ScriptTag_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() =>
                InputValidator.SanitizeUsername(
                    "<script>alert(1)</script>"));
        }
    }
}
