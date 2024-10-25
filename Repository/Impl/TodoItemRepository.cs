using todo_list_angular.Models;

namespace todo_list_angular.Repository.Impl
{
    public class TodoItemRepository : ITodoItemRepository
    {

        private readonly DbContexto _contexto;

        public TodoItemRepository(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public Task Add(TodoItem item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(TodoItem item)
        {
            throw new NotImplementedException();
        }
    }
}
