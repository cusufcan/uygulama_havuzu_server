using uygulama_havuzu_server.Core.Entities.Weather;

namespace uygulama_havuzu_server.Application.Interfaces {
    public interface IWeatherService {
        Task<WeatherModel?> GetWeatherAsync(string cityName);
    }
}
