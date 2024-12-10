using ToDo.Repositories.Interfaces;
using ToDo.Repositories.Model;
using ToDo.Services.Dto;
using ToDo.Services.Interfaces;

namespace ToDo.Services.Services
{
    public class TodoService : ITodoService
    {
        private ITodoRepositorie todoRepositorie;

        public TodoService(ITodoRepositorie todoRepositorie)
        {
            this.todoRepositorie = todoRepositorie;
        }

        public Task<long> CreateAsync(TodoCreateDto todoCreateDto)
        {
            return todoRepositorie.CreateAsync(new TodoItem
            {
                Title = todoCreateDto.Title,
                Description = todoCreateDto.Description,
                IsCompleted = todoCreateDto.IsCompleted,
                UserId = todoCreateDto.UserId,
                CategoryId = todoCreateDto.CategoryId,
            });
        }
    }
}
