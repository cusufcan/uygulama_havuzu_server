using System.Security.Cryptography;
using uygulama_havuzu_server.Core.Entities;
using uygulama_havuzu_server.Core.Interfaces;

namespace uygulama_havuzu_server.Application.Services {
    public class AuthService {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public async Task<bool> RegisterAsync(string username, string password) {
            var existingUser = await _userRepository.GetByUsernameAsync(username);
            if (existingUser != null) return false;

            var hashedPassword = HashPassword(password);
            var user = new User {
                Username = username,
                PasswordHash = hashedPassword,
            };
            await _userRepository.AddAsync(user);
            return true;
        }

        public async Task<bool> LoginAsync(string username, string password) {
            var user = await _userRepository.GetByUsernameAsync(username);
            return user != null && VerifyPassword(password, user.PasswordHash);
        }

        private string HashPassword(string password) {
            using (var hmac = new HMACSHA256()) {
                var hashedPassword = Convert.ToBase64String(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
                return hashedPassword;
            }
        }

        private bool VerifyPassword(string password, string storedHash) {
            var hashedPassword = HashPassword(password);
            return hashedPassword == storedHash;
        }
    }
}
