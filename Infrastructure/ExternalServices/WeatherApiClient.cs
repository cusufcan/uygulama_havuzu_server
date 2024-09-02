using uygulama_havuzu_server.Core.Entities.Weather;
using uygulama_havuzu_server.Core.Helper;
using uygulama_havuzu_server.Core.Interfaces;

namespace uygulama_havuzu_server.Infrastructure.ExternalServices {
    public class WeatherApiClient : IWeatherApiClient {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WeatherApiClient(HttpClient httpClient, IConfiguration configuration) {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<WeatherModel?> GetWeatherAsync(string cityName) {
            var baseUrl = _configuration["OpenWeather:BaseUrl"];
            var lang = _configuration["OpenWeather:Lang"];
            var key = _configuration["OpenWeather:Key"];
            var units = _configuration["OpenWeather:Units"];
            var url = $"{baseUrl}?q={cityName}&lang={lang}&appid={key}&units={units}";

            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode) {
                var responseData = await response.Content.ReadFromJsonAsync<WeatherModel>();
                if (responseData != null && responseData.Sys != null && responseData.Sys.Sunrise != null) {
                    responseData.Sys.SunriseString = UnixTimeHelper.ConvertUnixTimeToDateTimeString(responseData.Sys.Sunrise ?? 0);
                    responseData.Sys.SunsetString = UnixTimeHelper.ConvertUnixTimeToDateTimeString(responseData.Sys.Sunset ?? 0);
                }
                return responseData;
            } else {
                return null;
            }
        }
    }
}
