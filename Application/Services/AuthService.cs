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

            var user = new User {
                Username = username,
                Password = password,
            };
            await _userRepository.AddAsync(user);
            return true;
        }

        public async Task<bool> LoginAsync(string username, string password) {
            var user = await _userRepository.GetByUsernameAsync(username);
            return user != null && VerifyPassword(password, user.Password);
        }

        private bool VerifyPassword(string password, string storedPassword) {
            return password == storedPassword;
        }
    }
}
