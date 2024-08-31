namespace uygulama_havuzu_server.Core.Entities.Todo
{
    public class TodoModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required bool Completed { get; set; }
    }
}
