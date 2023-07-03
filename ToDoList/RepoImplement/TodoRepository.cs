using ToDoList.Model;
using ToDoList.Repo;

public class TodoRepository : ITodoRepository
{
    private static List<Todo> _todos = new List<Todo>();

    public IEnumerable<Todo> GetTodos()
    {
        return _todos;
    }

    public Todo CreateTodoItem(Todo todo)
    {
        int newId = _todos.Count + 1;
        todo.Id = newId;
        _todos.Add(todo);
        return todo;
    }

    public Todo UpdateTodoItem(int id, Todo updatedTodo)
    {
        Todo existingTodo = _todos.FirstOrDefault(t => t.Id == id);
        if (existingTodo == null)
        {
            return null;
        }
        existingTodo.Title = updatedTodo.Title;
        existingTodo.Description = updatedTodo.Description;
        existingTodo.IsCompleted = updatedTodo.IsCompleted;
        return existingTodo;
    }
}

