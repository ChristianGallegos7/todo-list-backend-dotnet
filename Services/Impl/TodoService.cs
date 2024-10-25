using todo_list_angular.DTOs.TodoItem;
using todo_list_angular.Models;
using todo_list_angular.Repository;

namespace todo_list_angular.Services.Impl
{
    public class TodoService : ITodoService
    {

        private readonly ITodoItemRepository _todoItemRepository;

        public TodoService(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<IEnumerable<TodoItemDto>> GetAll()
        {
            var todos = await _todoItemRepository.GetAll();

            return todos.Select(t => new TodoItemDto
            {
                Id = t.Id,
                Title = t.Title,
                IsCompleted = t.IsCompleted
            });
        }

        public async Task<TodoItemDto> Add(TodoItemInsertDto todoItemInsertDto)
        {
            var todo = new TodoItem
            {
                Title = todoItemInsertDto.Title,
                IsCompleted = todoItemInsertDto.IsCompleted
            };

            await _todoItemRepository.Add(todo);

            return new TodoItemDto
            {
                Id = todo.Id,
                Title = todo.Title,
                IsCompleted = todo.IsCompleted
            };
        }

        public async Task<TodoItemDto> DeleteById(int id)
        {
            var todo = await _todoItemRepository.GetById(id);

            if (todo == null) return null;

            await _todoItemRepository.Delete(id);

            return new TodoItemDto
            {
                Id = todo.Id,
                Title = todo.Title,
                IsCompleted = todo.IsCompleted
            };
        }

        public async Task<TodoItemDto> GetById(int id)
        {
            var todo = await _todoItemRepository.GetById(id);

            if (todo == null) return null;

            return new TodoItemDto
            {
                Id = todo.Id,
                Title = todo.Title,
                IsCompleted = todo.IsCompleted
            };
        }

        public async Task<TodoItemDto> Update(int id, TodoItemUpdateDto todoItemUpdateDto)
        {
            var todo = await _todoItemRepository.GetById(id);

            if (todo == null) return null;

            todo.Title = todoItemUpdateDto.Title;
            todo.IsCompleted = todoItemUpdateDto.IsCompleted;

            await _todoItemRepository.Update(todo);

            return new TodoItemDto
            {
                Id = todo.Id,
                Title = todo.Title,
                IsCompleted = todo.IsCompleted
            };

        }
    }
}
