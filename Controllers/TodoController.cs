using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo_list_angular.DTOs.TodoItem;
using todo_list_angular.Services;

namespace todo_list_angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetAll() {
            var todos = await _todoService.GetAll();

            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDto>> GetById(int id) {
            var todo = await _todoService.GetById(id);

            if(todo == null) return NotFound();

            return Ok(todo);
        }


        [HttpPost]
        public async Task<ActionResult<TodoItemDto>> Add(TodoItemInsertDto todoItemInsertDto){
            var todo = await _todoService.Add(todoItemInsertDto);

            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoItemDto>> Update(int id, TodoItemUpdateDto todoItemUpdateDto){
            var todo = await _todoService.Update(id, todoItemUpdateDto);

            if(todo == null) return NotFound();

            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItemDto>> DeleteById(int id) {
            var todo = await _todoService.DeleteById(id);

            if(todo == null) return NotFound();

            return Ok(todo);
        }
    }
}
