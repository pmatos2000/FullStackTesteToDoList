using ToDo.Services.Dto;

namespace ToDo.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<CategoryDto?> CreateAsync(long userId, string categoryName);
        public Task<IEnumerable<CategoryDto>> GetListCategoryAsync(long userId);
    }
}
