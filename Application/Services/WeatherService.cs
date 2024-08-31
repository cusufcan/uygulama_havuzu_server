using uygulama_havuzu_server.Application.Interfaces;
using uygulama_havuzu_server.Core.Entities.Weather;
using uygulama_havuzu_server.Core.Interfaces;

namespace uygulama_havuzu_server.Application.Services {
    public class WeatherService : IWeatherService {
        private readonly IWeatherApiClient _weatherApiClient;

        public WeatherService(IWeatherApiClient weatherApiClient) {
            _weatherApiClient = weatherApiClient;
        }

        public async Task<WeatherModel?> GetWeatherAsync(string cityName) {
            return await _weatherApiClient.GetWeatherAsync(cityName);
        }
    }
}
