using Microsoft.EntityFrameworkCore;
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

        public async Task Add(TodoItem item)
        {
            _contexto.TodoItems.Add(item);
            await _contexto.SaveChangesAsync();
        }


        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            return await _contexto.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetById(int id)
        {
            return await _contexto.TodoItems.FindAsync(id);
        }

        public async Task<bool> Update(TodoItem item)
        {
            _contexto.Entry(item).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0 ;
        }

        public async Task<bool> Delete(int id)
        {
            var todoItem = await _contexto.TodoItems.FindAsync(id);

            if(todoItem != null)
            {
                _contexto.TodoItems.Remove(todoItem);

               return await _contexto.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}
