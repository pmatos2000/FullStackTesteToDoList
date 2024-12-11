using ToDo.Repositories.Entitys;
using ToDo.Repositories.Interfaces;
using ToDo.Services.Dto;
using ToDo.Services.Interfaces;

namespace ToDo.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepositorie categoryRepositorie;

        public CategoryService(ICategoryRepositorie categoryRepositorie)
        {
            this.categoryRepositorie = categoryRepositorie;
        }

        public async Task<CategoryDto?> CreateAsync(long userId, string categoryName)
        {
            var categoryExists = await categoryRepositorie.VerifyCategoryNameAsync(userId, categoryName);

            if (categoryExists) return null;

            var newCategory = await categoryRepositorie.CreateCategoryAsync(userId, categoryName);

            return ConvertCategoryEntityToDto(newCategory);

        }

        public async Task<IEnumerable<CategoryDto>> GetListCategoryAsync(long userId)
        {
            var listCategory = await categoryRepositorie.GetListCategoryAsync(userId);
            return listCategory.Select(x => ConvertCategoryEntityToDto(x));
        }

        private static CategoryDto ConvertCategoryEntityToDto(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
            };
        }
    }
}
