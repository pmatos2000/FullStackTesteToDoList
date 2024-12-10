using ToDo.Repositories.Interfaces;
using ToDo.Repositories.Model;

namespace ToDo.Repositories.Repositories
{
    public class TodoRepositorie : ITodoRepositorie
    {
        private readonly AppDbContext appDbContext;
        public TodoRepositorie(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<long> CreateAsync(TodoItem todoItem)
        {
            var newTodoItem = await appDbContext.TodoItems.AddAsync(todoItem);
            await appDbContext.SaveChangesAsync();
            return newTodoItem.Entity.Id;
        }
    }
}
