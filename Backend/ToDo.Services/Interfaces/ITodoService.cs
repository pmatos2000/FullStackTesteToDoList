using ToDo.Services.Dto;

namespace ToDo.Services.Interfaces
{
    public interface ITodoService
    {
        public Task<long> CreateAsync(TodoCreateDto todoCreateDto);
    }
}
