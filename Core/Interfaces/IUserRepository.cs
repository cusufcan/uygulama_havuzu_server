using uygulama_havuzu_server.Core.Entities.User;

namespace uygulama_havuzu_server.Core.Interfaces {
    public interface IUserRepository {
        Task<UserModel?> GetByUsernameAsync(string username);
        Task AddAsync(UserModel user);
    }
}
