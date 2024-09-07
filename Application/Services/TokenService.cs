using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using uygulama_havuzu_server.Application.Interfaces;
using uygulama_havuzu_server.Core.Entities.Token;

namespace uygulama_havuzu_server.Application.Services {
    public class TokenService : ITokenService {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration) {
            _configuration = configuration;
        }

        public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request) {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"]));

            var now = DateTime.UtcNow;

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _configuration["AppSettings:ValidIssuer"],
                audience: _configuration["AppSettings:ValidAudience"],
                claims: new List<Claim> {
                    new Claim("userName", request.Username)
                },
                notBefore: now,
                expires: now.AddDays(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return Task.FromResult(new GenerateTokenResponse {
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                TokenExpireDate = now.AddDays(1)
            });
        }
    }
}
