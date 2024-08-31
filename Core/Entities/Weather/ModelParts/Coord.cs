using System.Text.Json.Serialization;

namespace uygulama_havuzu_server.Core.Entities.Weather.ModelParts {
    public class Coord {
        [JsonPropertyName("lon")]
        public double? Lon { get; set; }

        [JsonPropertyName("lat")]
        public double? Lat { get; set; }
    }
}
