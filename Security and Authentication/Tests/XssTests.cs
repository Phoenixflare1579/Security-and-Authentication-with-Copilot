using NUnit.Framework;
using SafeVault.Security;

namespace SafeVault.Tests
{
    [TestFixture]
    public class XssTests
    {
        [Test]
        public void ScriptTag_ShouldBeEncoded()
        {
            string payload =
                "<script>alert('XSS')</script>";

            string result =
                OutputEncoder.SafeDisplay(payload);

            Assert.IsFalse(
                result.Contains("<script>"));
        }

        [Test]
        public void ImgTag_ShouldBeEncoded()
        {
            string payload =
                "<img src=x onerror=alert(1)>";

            string result =
                OutputEncoder.SafeDisplay(payload);

            Assert.IsFalse(
                result.Contains("<img"));
        }
    }
}