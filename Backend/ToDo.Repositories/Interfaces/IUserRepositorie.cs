using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Repositories.Model.Entity;

namespace ToDo.Repositories.Interfaces
{
    public interface IUserRepositorie
    {
        public Task<bool> VerifyUserNameAsync(string userName);
        public Task RegisterAsync(string userName, string passwordHash);
        public Task<UserLogin?> GetUserLoginByNameAsync(string userName);
    }
}
