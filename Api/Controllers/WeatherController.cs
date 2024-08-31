using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uygulama_havuzu_server.Application.Interfaces;

namespace uygulama_havuzu_server.Api.Controllers {
    [ApiController]
    [Route("api/weather")]
    public class WeatherController : ControllerBase {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService) {
            _weatherService = weatherService;
        }

        [HttpGet("{cityName}")]
        [Authorize]
        public async Task<IActionResult> GetWeather(string cityName) {
            var resultData = await _weatherService.GetWeatherAsync(cityName);
            if (resultData != null) {
                return Ok(resultData);
            } else {
                return NotFound();
            }
        }
    }
}
