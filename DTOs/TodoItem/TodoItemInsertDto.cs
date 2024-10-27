namespace todo_list_angular.DTOs.TodoItem
{
    public class TodoItemInsertDto
    {
        public string Title { get; set; } = null!;
        public bool IsCompleted { get; set; }
    }
}
