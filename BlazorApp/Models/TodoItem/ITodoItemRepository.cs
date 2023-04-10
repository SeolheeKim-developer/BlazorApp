using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Models.TodoItem
{
    public interface ITodoItemRepository
    {

        Task<List<TodoItem>> GetAll();
        Task<TodoItem> GetById(int id);
        Task Create(TodoItem item);
        Task Update(TodoItem item);
        Task Delete(int id);

    }
}
