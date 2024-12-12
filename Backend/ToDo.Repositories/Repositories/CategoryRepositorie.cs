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

        public async Task<long?> DeleteCategoryAsync(long userId, long categoryId)
        {
            var category = await appDbContext.Categories
               .FirstOrDefaultAsync(t => t.Id == categoryId && t.UserId == userId);

            if (category == null) return null;

            appDbContext.Categories.Remove(category);

            await appDbContext.SaveChangesAsync();

            return category.Id;
        }

        public async Task<IEnumerable<Category>> GetListCategoryAsync(long userId)
        {
            var listCategory = await appDbContext.Categories
                .Where(x => x.UserId == userId)
                .OrderBy(x => x.Name)
                .ToListAsync();

            return listCategory;
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
