using ToDo.Repositories.Entitys;

namespace ToDo.Repositories.Interfaces
{
    public interface ICategoryRepositorie
    {
        public Task<bool> VerifyCategoryNameAsync(long userId, string categoryName);
        public Task<Category> CreateCategoryAsync(long userId, string categoryName);
        public Task<IEnumerable<Category>> GetListCategoryAsync(long userId);
        public Task<long?> DeleteCategoryAsync(long userId, long categoryId);
    }
}
