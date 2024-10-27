using todo_list_angular.DTOs.TodoItem;

namespace todo_list_angular.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItemDto>> GetAll();

        Task<TodoItemDto> GetById(int id);

        Task<TodoItemDto> Add(TodoItemInsertDto todoItemInsertDto);

        Task<TodoItemDto> Update(int id, TodoItemUpdateDto todoItemUpdateDto);

        Task<TodoItemDto> DeleteById(int id);
    }
}
