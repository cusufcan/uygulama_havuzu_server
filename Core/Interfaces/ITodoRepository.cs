using uygulama_havuzu_server.Core.Entities;

namespace uygulama_havuzu_server.Core.Interfaces {
    public interface ITodoRepository {
        Task<IEnumerable<Todo>> GetAllTodosAsync();
        Task<Todo> GetTodoAsync(int id);
        Task AddTodoAsync(Todo todo);
        Task UpdateTodoAsync(Todo todo);
        Task DeleteTodoAsync(Todo todo);
    }
}
