using uygulama_havuzu_server.Core.Entities.User;

namespace uygulama_havuzu_server.Application.Interfaces {
    public interface IAuthService {
        public Task<UserAuthResponse> LoginUserAsync(UserAuthRequest userAuthRequest);
        public Task<UserAuthResponse> RegisterUserAsync(UserAuthRequest userAuthRequest);
    }
}
