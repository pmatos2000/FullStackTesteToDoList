using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Repositories.Entitys;

namespace ToDo.Repositories.Interfaces
{
    public interface ICategoryRepositorie
    {
        public Task<bool> VerifyCategoryNameAsync(long userId, string categoryName);
        public Task<Category> CreateCategoryAsync(long userId, string categoryName);
    }
}
