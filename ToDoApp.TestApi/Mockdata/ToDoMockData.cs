using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;
namespace ToDoApp.TestApi.Mockdata;

public class ToDoMockData
{
    public static List<ToDo> GetTodos()
    {
        return new List<ToDo>{
             new ToDo{
                 Id = 1,
                 ItemName = "Need To Go Shopping",
                 IsCompleted = true
             },
             new ToDo{
                 Id = 2,
                 ItemName = "Cook Food",
                 IsCompleted = true
             },
             new ToDo{
                 Id = 3,
                 ItemName = "Play Games",
                 IsCompleted = false
             }
         };
    }
    public static List<ToDo> GetEmptyTodos()
    {
        return new List<ToDo>();
    }
    public static ToDo NewTodo()
    {                    
        return new ToDo
        {
            Id = 0,
            ItemName = "wash cloths",
            IsCompleted = false
        };
    }
}
