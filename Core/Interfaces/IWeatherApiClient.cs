using uygulama_havuzu_server.Core.Entities.Weather;

namespace uygulama_havuzu_server.Core.Interfaces {
    public interface IWeatherApiClient {
        public Task<WeatherModel?> GetWeatherAsync(string cityName);
    }
}
