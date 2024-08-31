using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uygulama_havuzu_server.Application.Interfaces;
using uygulama_havuzu_server.Core.Entities.User;

namespace uygulama_havuzu_server.Api.Controllers {
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) {
            _authService = authService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<UserAuthResponse>> Register([FromBody] UserAuthRequest request) {
            var result = await _authService.RegisterUserAsync(request);
            return result;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserAuthResponse>> Login([FromBody] UserAuthRequest request) {
            var result = await _authService.LoginUserAsync(request);
            return result;
        }
    }
}
