using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Services.Interfaces;

namespace ToDo.Services.Services
{
    public class CategoryService : ICategoryService
    {
        public Task<bool> CreateAsync(long userId, string categoryName)
        {
            throw new NotImplementedException();
        }
    }
}
