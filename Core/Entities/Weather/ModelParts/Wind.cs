using System.Text.Json.Serialization;

namespace uygulama_havuzu_server.Core.Entities.Weather.ModelParts {
    public class Wind {
        [JsonPropertyName("speed")]
        public double? Speed { get; set; }

        [JsonPropertyName("deg")]
        public double? Deg { get; set; }

        [JsonPropertyName("gust")]
        public double? Gust { get; set; }
    }
}
