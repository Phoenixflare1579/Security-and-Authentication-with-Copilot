using System.Net;

namespace SafeVault.Security
{
    public static class OutputEncoder
    {
        public static string SafeDisplay(string content)
        {
            return WebUtility.HtmlEncode(content);
        }
    }
}