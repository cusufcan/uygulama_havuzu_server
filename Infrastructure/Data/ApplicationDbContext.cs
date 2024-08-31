using Microsoft.EntityFrameworkCore;
using uygulama_havuzu_server.Core.Entities.Todo;
using uygulama_havuzu_server.Core.Entities.User;

namespace uygulama_havuzu_server.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TodoModel> Todos { get; set; }
    }
}
