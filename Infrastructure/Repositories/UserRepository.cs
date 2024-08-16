using Microsoft.EntityFrameworkCore;
using uygulama_havuzu_server.Core.Entities;
using uygulama_havuzu_server.Core.Interfaces;
using uygulama_havuzu_server.Infrastructure.Data;

namespace uygulama_havuzu_server.Infrastructure.Repositories {
    public class UserRepository : IUserRepository {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task AddAsync(User user) {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByUsernameAsync(string username) {
            return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
        }
    }
}
