using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ToDoList.Model;
using ToDoList.Repo;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoesController : ControllerBase
    {
        

        private readonly ITodoRepository _todoRepository;

        public TodoesController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        // GET: api/Todoes
        [HttpGet]
        public ActionResult<IEnumerable<Todo>> GetTodos()
        {
            var todos = _todoRepository.GetTodos();
            return Ok(todos);
        }

        // POST: api/Todoes
        [HttpPost]
        public ActionResult<Todo> CreateTodoItem(Todo todo)
        {
            var createdTodo = _todoRepository.CreateTodoItem(todo);
            return CreatedAtAction(nameof(GetTodos), new { id = createdTodo.Id }, createdTodo);
        }

        // PUT: api/Todoes/{Id}
        [HttpPut("{id}")]
        public ActionResult<Todo> UpdateTodoItem(int id, Todo updatedTodo)
        {
            var existingTodo = _todoRepository.UpdateTodoItem(id, updatedTodo);
            if (existingTodo == null)
            {
                return NotFound();
            }
            return existingTodo;
        }







    }
}
