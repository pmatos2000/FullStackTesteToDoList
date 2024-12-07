using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> VerifyUserName(string userName);
        public Task<bool> Register(string userName, string password);
    }
}
