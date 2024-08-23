using Microsoft.AspNetCore.Mvc;
using uygulama_havuzu_server.Application.Services;

namespace uygulama_havuzu_server.Api.Controllers {
    [ApiController]
    [Route("api/todo")]
    public class TodoController : ControllerBase {
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService) {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos() {
            var todos = await _todoService.GetAllTodosAsync();
            return Ok(todos);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo(string title) {
            var result = await _todoService.AddTodoAsync(title);
            return result ? Ok() : BadRequest("An error occurred while adding the todo.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTodo(int id, bool isCompleted) {
            var result = await _todoService.UpdateTodoAsync(id, isCompleted);
            return result ? Ok() : BadRequest("An error occurred while updating the todo.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTodo(int id) {
            var result = await _todoService.DeleteTodoAsync(id);
            return result ? Ok() : BadRequest("An error occurred while deleting the todo.");
        }
    }
}
