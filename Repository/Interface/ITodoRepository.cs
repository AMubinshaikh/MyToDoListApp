using System.Collections.Generic;
using System.Threading.Tasks;
using MyTodoApp_ISG.Model;

public interface ITodoRepository
{
    Task<List<Todo>> GetAll();
    Task<int> Add(Todo todo);
    Task<bool> Update(int Id, Todo todo);
    Task<bool> Delete(int Id);
    Task<bool> MarkCompleted(int Id, bool IsCompleted);
} 