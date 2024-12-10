using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Repositories.Model;

namespace ToDo.Repositories.Interfaces
{
    public interface ITodoRepositorie
    {
        public Task<long> CreateAsync(TodoItem todoItem);
    }
}
