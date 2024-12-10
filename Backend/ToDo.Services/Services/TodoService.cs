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

        private static TodoItem ConvertTodoCreateDtoToEntity(TodoCreateDto todoCreateDto)
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

        public async Task<TodoItemDto?> GetTodoAsync(long userId, long id)
        {
            var todoItem = await todoRepositorie.GetTodoAsync(userId, id);
            if (todoItem == null) return null;
            return ConvertTodoItemEntityToDto(todoItem);
        }

        private static TodoItemDto ConvertTodoItemEntityToDto(TodoItem item)
        {
            return new TodoItemDto
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted,
                CategoryId = item.CategoryId,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt
            };
        }
    }
}
