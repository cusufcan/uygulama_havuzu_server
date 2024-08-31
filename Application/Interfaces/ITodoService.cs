using uygulama_havuzu_server.Core.Entities.Todo;

namespace uygulama_havuzu_server.Application.Interfaces {
    public interface ITodoService {
        Task<IEnumerable<TodoModel>> GetAllTodosAsync();
        Task<bool> AddTodoAsync(string title);
        Task<bool> UpdateTodoAsync(int id, bool isCompleted);
        Task<bool> DeleteTodoAsync(int id);
    }
}
