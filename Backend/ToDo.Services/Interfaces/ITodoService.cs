using ToDo.Services.Dto;

namespace ToDo.Services.Interfaces
{
    public interface ITodoService
    {
        public Task<long> CreateAsync(TodoCreateDto todoCreateDto);
        public Task<long?> TodoUpdateAsync(long todoId, TodoCreateDto todoCreateDto);
        public Task<long?> TodoUpdateCompletionStatusAsync(long userId, long todoId, bool isCompleted);

    }
}
