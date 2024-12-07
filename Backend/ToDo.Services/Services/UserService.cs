using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Repositories.Interfaces;
using ToDo.Services.Interfaces;
using ToDo.Shared.Util;

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

        public async Task<bool> Register(string userName, string password)
        {
            var verifyUserName = await VerifyUserName(userName);
            if (verifyUserName) return false;

            var passwordHash = Password.PasswordHash(password);

            await userRepositorie.Register(userName, passwordHash);

            return true;
        }
    }
}
