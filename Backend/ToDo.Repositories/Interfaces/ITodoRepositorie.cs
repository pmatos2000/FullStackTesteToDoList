using ToDo.Repositories.Model;

namespace ToDo.Repositories.Interfaces
{
    public interface ITodoRepositorie
    {
        public Task<long> CreateAsync(TodoItem todoItem);
        public Task<long?> TodoUpdateAsync(long todoId, TodoItem todoItem);
        public Task<long?> TodoUpdateCompletionStatusAsync(long userId, long todoId, bool isCompleted);
        public Task<TodoItem?> GetTodoAsync(long userId, long id);
        public Task<IEnumerable<TodoItem>> GetListTodoAsync(long userId, long? categoryId);
        public Task<long?> DeleteTodoAsync(long userId, long id);
    }
}
