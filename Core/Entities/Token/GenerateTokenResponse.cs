namespace uygulama_havuzu_server.Core.Entities.Token {
    public class GenerateTokenResponse {
        public required string Token { get; set; }
        public DateTime TokenExpireDate { get; set; }
    }
}
