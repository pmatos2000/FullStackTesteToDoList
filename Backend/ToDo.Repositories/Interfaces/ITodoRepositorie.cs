using ToDo.Repositories.Model;

namespace ToDo.Repositories.Interfaces
{
    public interface ITodoRepositorie
    {
        public Task<long> CreateAsync(TodoItem todoItem);
        public Task<long?> TodoUpdateAsync(long todoId, TodoItem todoItem);
    }
}
