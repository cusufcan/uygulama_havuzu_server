﻿namespace uygulama_havuzu_server.Core.Entities {
    public class User {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
