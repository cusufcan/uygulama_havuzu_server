using uygulama_havuzu_server.Core.Entities;

namespace uygulama_havuzu_server.Core.Interfaces {
    public interface IUserRepository {
        Task<User> GetByUsernameAsync(string username);
        Task AddAsync(User user);
    }
}
