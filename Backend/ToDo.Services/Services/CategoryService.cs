using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            return new CategoryDto
            {
                Id = newCategory.Id,
                Name = newCategory.Name,
            };

        }
    }
}
