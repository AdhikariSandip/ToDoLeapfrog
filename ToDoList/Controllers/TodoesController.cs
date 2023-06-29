using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ToDoList.Model;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoesController : ControllerBase
    {
        private static List<Todo> _todos = new List<Todo>();
        // GET: api/Todoes
        [HttpGet]
        public ActionResult<IEnumerable<Todo>> GetTodos()
        {
            return _todos;
        }
        // POST: api/Todoes
        [HttpPost]
        public ActionResult<Todo> CreateTodoItem(Todo todo)
        {
           
            int newId = _todos.Count + 1;
            todo.Id = newId;

            
            _todos.Add(todo);

            // Return the created todo item with HTTP 201 Created status
            return CreatedAtAction(nameof(GetTodos), new { id = todo.Id }, todo);
        }
        // PUT: api/Todoes/{Id}
        [HttpPut("{id}")]
        public ActionResult<Todo> UpdateTodoItem(int id, Todo updatedTodo)
        {
            
            Todo existingTodo = _todos.FirstOrDefault(t => t.Id == id);
            if (existingTodo == null)
            {
                return NotFound();
            }

            // Update the properties of the existing todo item
            existingTodo.Title = updatedTodo.Title;
            existingTodo.Description = updatedTodo.Description;
            existingTodo.IsCompleted = updatedTodo.IsCompleted;

            // Return the updated todo item
            return existingTodo;
        }






    }
}
