using System.Text.Json.Serialization;

namespace uygulama_havuzu_server.Core.Entities.Weather.ModelParts {
    public class Clouds {
        [JsonPropertyName("all")]
        public double? All { get; set; }
    }

}
