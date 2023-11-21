using System;


using ToDoList.Model;


namespace ToDoList.Controllers
{
    // TodoController.cs
    using Microsoft.AspNetCore.Mvc;
    using ToDoList.Services;

    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var todos = _todoService.GetAll();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todo = _todoService.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Todo todo)
        {
            _todoService.Add(todo);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Todo todo)
        {
            var existingTodo = _todoService.GetById(id);
            if (existingTodo == null)
            {
                return NotFound();
            }

            existingTodo.Title = todo.Title;
            existingTodo.IsCompleted = todo.IsCompleted;

            _todoService.Update(existingTodo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingTodo = _todoService.GetById(id);
            if (existingTodo == null)
            {
                return NotFound();
            }

            _todoService.Delete(id);

            return NoContent();
        }
    }




}

