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

        public Task<bool> VerifyUserNameAsync(string userName)
        {
            return userRepositorie.VerifyUserNameAsync(userName);
        }

        public async Task<bool> RegisterAsync(string userName, string password)
        {
            var verifyUserName = await VerifyUserNameAsync(userName);
            if (verifyUserName) return false;

            var passwordHash = Password.PasswordHash(password);

            await userRepositorie.RegisterAsync(userName, passwordHash);

            return true;
        }
    }
}
