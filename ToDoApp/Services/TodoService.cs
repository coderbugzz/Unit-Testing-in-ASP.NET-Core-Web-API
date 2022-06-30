using ToDoApp.Data;
using ToDoApp.Models;
using Microsoft.EntityFrameworkCore;
namespace ToDoApp.Services
{
    public class TodoService : ITodoService
    {
        private readonly ToDoDbContext _context;
        public TodoService(ToDoDbContext context)
        {
            _context = context;
        }

        public async Task<List<ToDo>> GetAllAsync()
        {
            return await _context.ToDo.ToListAsync();
        }

        public async Task SaveAsync(ToDo newToDo)
        {
            _context.ToDo.Add(newToDo);
            await _context.SaveChangesAsync();
        }
    }
}
