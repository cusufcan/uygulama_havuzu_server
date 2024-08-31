using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uygulama_havuzu_server.Application.Interfaces;
using uygulama_havuzu_server.Core.Entities.Todo;

namespace uygulama_havuzu_server.Api.Controllers {
    [ApiController]
    [Route("api/todo")]
    public class TodoController : ControllerBase {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService) {
            _todoService = todoService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetTodos() {
            var todos = await _todoService.GetAllTodosAsync();
            return Ok(todos);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddTodo([FromBody] AddTodoRequest request) {
            var result = await _todoService.AddTodoAsync(request.Title);
            return result ? Ok() : BadRequest("An error occurred while adding the todo.");
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateTodo([FromBody] UpdateTodoRequest request) {
            var result = await _todoService.UpdateTodoAsync(request.Id, request.IsCompleted);
            return result ? Ok() : BadRequest("An error occurred while updating the todo.");
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteTodo([FromBody] DeleteTodoRequest request) {
            var result = await _todoService.DeleteTodoAsync(request.Id);
            return result ? Ok() : BadRequest("An error occurred while deleting the todo.");
        }
    }
}
