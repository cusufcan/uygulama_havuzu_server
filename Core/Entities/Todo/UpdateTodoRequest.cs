namespace uygulama_havuzu_server.Core.Entities.Todo {
    public class UpdateTodoRequest {
        public int Id { get; set; }
        public bool IsCompleted { get; set; }
    }
}
