using uygulama_havuzu_server.Core.Entities.Token;

namespace uygulama_havuzu_server.Application.Interfaces {
    public interface ITokenService {
        public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
    }
}
