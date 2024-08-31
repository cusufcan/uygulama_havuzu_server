using System.Text.Json.Serialization;

namespace uygulama_havuzu_server.Core.Entities.Weather.ModelParts {
    public class Main {
        [JsonPropertyName("temp")]
        public double? Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public double? FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public double? TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        public double? TempMax { get; set; }

        [JsonPropertyName("pressure")]
        public double? Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public double? Humidity { get; set; }

        [JsonPropertyName("sea_level")]
        public double? SeaLevel { get; set; }

        [JsonPropertyName("grnd_level")]
        public double? GrndLevel { get; set; }
    }
}
