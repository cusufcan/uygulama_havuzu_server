using Microsoft.EntityFrameworkCore;
using uygulama_havuzu_server.Core.Entities;
using uygulama_havuzu_server.Core.Interfaces;
using uygulama_havuzu_server.Infrastructure.Data;

namespace uygulama_havuzu_server.Infrastructure.Repositories {
    public class TodoRepository : ITodoRepository {
        private readonly ApplicationDbContext _context;

        public TodoRepository(ApplicationDbContext context) {
            _context = context;
        }

        // Create
        public async Task AddTodoAsync(Todo todo) {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
        }

        // Read
        public async Task<IEnumerable<Todo>> GetAllTodosAsync() {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo> GetTodoAsync(int id) {
            return await _context.Todos.SingleOrDefaultAsync(t => t.Id == id);
        }

        // Update
        public async Task UpdateTodoAsync(Todo todo) {
            _context.Todos.Update(todo);
            await _context.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteTodoAsync(Todo todo) {
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
        }
    }
}
