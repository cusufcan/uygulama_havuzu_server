using uygulama_havuzu_server.Core.Entities.Todo;

namespace uygulama_havuzu_server.Core.Interfaces {
    public interface ITodoRepository {
        Task<IEnumerable<TodoModel>> GetAllTodosAsync();
        Task<TodoModel> GetTodoAsync(int id);
        Task AddTodoAsync(TodoModel todo);
        Task UpdateTodoAsync(TodoModel todo);
        Task DeleteTodoAsync(TodoModel todo);
    }
}
