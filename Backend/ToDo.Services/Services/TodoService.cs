using ToDo.Repositories.Interfaces;
using ToDo.Repositories.Model;
using ToDo.Services.Dto;
using ToDo.Services.Interfaces;

namespace ToDo.Services.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepositorie todoRepositorie;

        public TodoService(ITodoRepositorie todoRepositorie)
        {
            this.todoRepositorie = todoRepositorie;
        }

        public Task<long> CreateAsync(TodoCreateDto todoCreateDto)
        {
            var todoItem = ConvertTodoCreateDtoToEntity(todoCreateDto);
            return todoRepositorie.CreateAsync(todoItem);
        }

        public Task<long?> TodoUpdateAsync(long todoId, TodoCreateDto todoCreateDto)
        {
            var todoItem = ConvertTodoCreateDtoToEntity(todoCreateDto);
            return todoRepositorie.TodoUpdateAsync(todoId, todoItem);
        }

        public Task<long?> TodoUpdateCompletionStatusAsync(long userId, long todoId, bool isCompleted)
        {
            return todoRepositorie.TodoUpdateCompletionStatusAsync(userId, todoId, isCompleted);
        }

        private TodoItem ConvertTodoCreateDtoToEntity(TodoCreateDto todoCreateDto)
        {
            return new TodoItem
            {
                Title = todoCreateDto.Title,
                Description = todoCreateDto.Description,
                IsCompleted = todoCreateDto.IsCompleted,
                UserId = todoCreateDto.UserId,
                CategoryId = todoCreateDto.CategoryId,
            };
        }
    }
}
