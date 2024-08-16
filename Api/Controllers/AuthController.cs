using Microsoft.AspNetCore.Mvc;
using uygulama_havuzu_server.Application.Services;

namespace uygulama_havuzu_server.Api.Controllers {
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase {
        private readonly AuthService _authService;

        public AuthController(AuthService authService) {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password) {
            var result = await _authService.RegisterAsync(username, password);
            return result ? Ok() : BadRequest("User already exists.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password) {
            var result = await _authService.LoginAsync(username, password);
            return result ? Ok() : Unauthorized();
        }
    }
}
