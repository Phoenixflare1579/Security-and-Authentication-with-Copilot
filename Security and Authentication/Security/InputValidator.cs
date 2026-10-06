using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SafeVault.Security
{
    public static class InputValidator
    {
        private static readonly Regex UsernameRegex =
            new Regex(@"^[a-zA-Z0-9_-]{3,50}$");

        public static string SanitizeUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username is required.");

            username = username.Trim();

            if (!UsernameRegex.IsMatch(username))
                throw new ArgumentException("Invalid username.");

            return username;
        }

        public static string SanitizeEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required.");

            email = email.Trim();

            try
            {
                var mailAddress = new MailAddress(email);

                if (mailAddress.Address != email)
                    throw new ArgumentException("Invalid email.");

                return mailAddress.Address;
            }
            catch
            {
                throw new ArgumentException("Invalid email.");
            }
        }
    }
}
``