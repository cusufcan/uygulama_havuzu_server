using System.Text.Json.Serialization;

namespace uygulama_havuzu_server.Core.Entities.Weather.ModelParts {
    public class Sys {
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("sunrise")]
        public long? Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public long? Sunset { get; set; }

        public string? SunriseString { get; set; }
        public string? SunsetString { get; set; }
    }
}
