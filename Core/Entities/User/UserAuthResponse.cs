namespace uygulama_havuzu_server.Core.Entities.User {
    public class UserAuthResponse {
        public bool AuthResult { get; set; }
        public string? Token { get; set; }
        public DateTime TokenExpireDate { get; set; }
    }
}
