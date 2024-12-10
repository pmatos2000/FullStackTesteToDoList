using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Services.Dto;

namespace ToDo.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<CategoryDto?> CreateAsync(long userId, string categoryName);
    }
}
