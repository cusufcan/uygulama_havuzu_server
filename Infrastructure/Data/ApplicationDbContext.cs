using Microsoft.EntityFrameworkCore;
using uygulama_havuzu_server.Core.Entities;

namespace uygulama_havuzu_server.Infrastructure.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }
    }
}
