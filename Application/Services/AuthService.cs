using uygulama_havuzu_server.Application.Interfaces;
using uygulama_havuzu_server.Core.Entities.Token;
using uygulama_havuzu_server.Core.Entities.User;
using uygulama_havuzu_server.Core.Interfaces;

namespace uygulama_havuzu_server.Application.Services {
    public class AuthService : IAuthService {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, ITokenService tokenService) {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<UserAuthResponse> LoginUserAsync(UserAuthRequest request) {
            UserAuthResponse response = new UserAuthResponse {
                AuthResult = false,
                Token = string.Empty,
                TokenExpireDate = DateTime.UtcNow,
            };

            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password)) {
                throw new ArgumentNullException(nameof(request));
            }

            var user = await _userRepository.GetByUsernameAsync(request.Username);
            if (user != null && VerifyPassword(request.Password, user.Password)) {
                var generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequest {
                    Username = user.Username,
                });

                response.AuthResult = true;
                response.Token = generatedTokenInformation.Token;
                response.TokenExpireDate = generatedTokenInformation.TokenExpireDate;
            }

            return response;
        }

        public async Task<UserAuthResponse> RegisterUserAsync(UserAuthRequest request) {
            UserAuthResponse response = new UserAuthResponse {
                AuthResult = false,
                Token = string.Empty,
                TokenExpireDate = DateTime.UtcNow,
            };

            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password)) {
                throw new ArgumentNullException(nameof(request));
            }

            var user = new UserModel {
                Username = request.Username,
                Password = request.Password,
            };

            var existingUser = await _userRepository.GetByUsernameAsync(user.Username);
            if (existingUser == null) {
                var generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequest {
                    Username = user.Username,
                });

                response.AuthResult = true;
                response.Token = generatedTokenInformation.Token;
                response.TokenExpireDate = generatedTokenInformation.TokenExpireDate;

                await _userRepository.AddAsync(user);
            }

            return response;
        }

        private bool VerifyPassword(string password, string storedPassword) {
            return password == storedPassword;
        }
    }
}
