using System.Text.Json.Serialization;

namespace uygulama_havuzu_server.Core.Entities.Weather.ModelParts {
    public class WeatherCondition {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("main")]
        public string? Main { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("icon")]
        public string? Icon { get; set; }
    }
}
