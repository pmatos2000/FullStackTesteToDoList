using Microsoft.EntityFrameworkCore;
using ToDo.Repositories.Entitys;
using ToDo.Repositories.Interfaces;

namespace ToDo.Repositories.Repositories
{
    public class CategoryRepositorie : ICategoryRepositorie
    {
        private readonly AppDbContext appDbContext;
        public CategoryRepositorie(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Category> CreateCategoryAsync(long userId, string categoryName)
        {
            var newCategoy = await appDbContext.Categories.AddAsync(new Category
            {
                Name = categoryName,
                UserId = userId,
            });
            await appDbContext.SaveChangesAsync();
            return newCategoy.Entity;
        }

        public Task<bool> VerifyCategoryNameAsync(long userId, string categoryName)
        {
            var normalizedCategoryName = categoryName.ToLower();
            return appDbContext.Categories
                .AnyAsync(x => x.Name.ToLower() == normalizedCategoryName
                    && x.UserId == userId);
        }
    }
}
