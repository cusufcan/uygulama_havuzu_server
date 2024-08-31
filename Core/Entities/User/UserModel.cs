namespace uygulama_havuzu_server.Core.Entities.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
