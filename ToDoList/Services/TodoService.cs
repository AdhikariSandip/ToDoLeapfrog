namespace ToDoList.Services
{
    using Microsoft.EntityFrameworkCore;
    // TodoService.cs
    using System.Collections.Generic;
    using System.Linq;
    using ToDoList.Data;
    using ToDoList.Model;

    public class TodoService
    {
        private readonly TodoDbContext _dbContext;

        public TodoService(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Todo> GetAll()
        {
            return _dbContext.Todos.ToList();
        }

        public Todo GetById(int id)
        {
            return _dbContext.Todos.Find(id);
        }

        public void Add(Todo todo)
        {
            _dbContext.Todos.Add(todo);
            _dbContext.SaveChanges();
        }

        public void Update(Todo todo)
        {
            _dbContext.Entry(todo).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var todo = _dbContext.Todos.Find(id);
            if (todo != null)
            {
                _dbContext.Todos.Remove(todo);
                _dbContext.SaveChanges();
            }
        }
    }

}
