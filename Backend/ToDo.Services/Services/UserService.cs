using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Repositories.Interfaces;
using ToDo.Services.Interfaces;

namespace ToDo.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepositorie userRepositorie;

        public UserService(IUserRepositorie userRepositorie)
        {
            this.userRepositorie = userRepositorie;
        }

        public Task<bool> VerifyUserName(string userName)
        {
            return userRepositorie.VerifyUserName(userName);
        }
    }
}
