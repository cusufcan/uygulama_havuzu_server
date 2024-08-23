using uygulama_havuzu_server.Core.Entities;
using uygulama_havuzu_server.Core.Interfaces;

namespace uygulama_havuzu_server.Application.Services {
    public class TodoService {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository) {
            _todoRepository = todoRepository;
        }

        // Create
        public async Task<bool> AddTodoAsync(string title) {
            Todo todo = new Todo {
                Title = title,
                Completed = false,
            };
            await _todoRepository.AddTodoAsync(todo);
            return true;
        }

        // Read
        public async Task<IEnumerable<Todo>> GetAllTodosAsync() {
            return await _todoRepository.GetAllTodosAsync();
        }

        // Update
        public async Task<bool> UpdateTodoAsync(int id, bool isCompleted) {
            var todo = await _todoRepository.GetTodoAsync(id);
            if (todo == null) return false;

            todo.Completed = isCompleted;
            await _todoRepository.UpdateTodoAsync(todo);
            return true;
        }

        // Delete
        public async Task<bool> DeleteTodoAsync(int id) {
            var todo = await _todoRepository.GetTodoAsync(id);
            if (todo == null) return false;
            await _todoRepository.DeleteTodoAsync(todo);
            return true;
        }
    }
}
