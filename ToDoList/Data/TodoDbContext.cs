namespace ToDoList.Data
{
    using Microsoft.EntityFrameworkCore;
    using ToDoList.Model;

    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

        public DbSet<Todo> Todos { get; set; }
    }
}
