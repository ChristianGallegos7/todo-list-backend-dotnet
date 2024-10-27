namespace todo_list_angular.DTOs.TodoItem
{
    public class TodoItemDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public bool IsCompleted { get; set; }
    }
}
