using todo_list_angular.DTOs.TodoItem;

namespace todo_list_angular.Services.Impl
{
    public class TodoService : ITodoService
    {

        public Task<IEnumerable<TodoItemDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TodoItemDto> Add(TodoItemInsertDto todoItemInsertDto)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItemDto> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItemDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItemDto> Update(int id, TodoItemUpdateDto todoItemUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
