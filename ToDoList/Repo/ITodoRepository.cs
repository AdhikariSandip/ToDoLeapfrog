using ToDoList.Model;

namespace ToDoList.Repo
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetTodos();
        Todo CreateTodoItem(Todo todo);
        Todo UpdateTodoItem(int id, Todo updatedTodo);
    }
}
