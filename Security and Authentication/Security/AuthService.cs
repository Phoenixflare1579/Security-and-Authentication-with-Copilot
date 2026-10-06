using SafeVault.Data;

namespace SafeVault.Security
{
    public class AuthService
    {
        private readonly UserRepository _userRepository;

        public AuthService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Authenticate(
            string username,
            string password)
        {
            var user =
                _userRepository.GetUserByUsername(username);

            if (user == null)
                return false;

            return PasswordService.VerifyPassword(
                password,
                user.PasswordHash);
        }
    }
}