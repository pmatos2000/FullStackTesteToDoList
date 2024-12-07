using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Repositories.Interfaces;

namespace ToDo.Repositories.Repositories
{
    public class UserRepositorie : IUserRepositorie
    {
        private readonly AppDbContext appDbContext;

        public UserRepositorie(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Task<bool> VerifyUserName(string userName)
        {
            var normalizedUserName = userName.ToLower();
            return appDbContext.Users
                .AnyAsync(x => x.UserName.ToLower() == normalizedUserName);
        }
    }
}
