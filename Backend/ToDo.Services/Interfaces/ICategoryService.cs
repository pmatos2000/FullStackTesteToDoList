using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<bool> CreateAsync(long userId, string categoryName);
    }
}
