using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.Services
{
   
        public interface ITodoService
        {
            Task<List<ToDo>> GetAllAsync();
            Task SaveAsync(ToDo newTodo);
        }
    
}
