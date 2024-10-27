using todo_list_angular.Models;

namespace todo_list_angular.Repository
{
    public interface ITodoItemRepository
    {
        Task<IEnumerable<TodoItem>> GetAll();

        Task<TodoItem> GetById(int id);

        Task Add(TodoItem item);

        Task<bool> Update(TodoItem item);

        Task<bool> Delete(int id);
    }
}
