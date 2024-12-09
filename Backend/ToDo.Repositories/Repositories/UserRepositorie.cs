using Microsoft.EntityFrameworkCore;

using ToDo.Repositories.Interfaces;
using ToDo.Repositories.Model.Entity;

namespace ToDo.Repositories.Repositories
{
    public class UserRepositorie : IUserRepositorie
    {
        private readonly AppDbContext appDbContext;

        public UserRepositorie(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Task<UserLogin> GetUserByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterAsync(string userName, string passwordHash)
        {
            var newUser = new User
            {
                UserName = userName,
                PasswordHash = passwordHash,
            };

            await appDbContext.Users.AddAsync(newUser);
            await appDbContext.SaveChangesAsync();
        }

        public Task<bool> VerifyUserNameAsync(string userName)
        {
            var normalizedUserName = userName.ToLower();
            return appDbContext.Users
                .AnyAsync(x => x.UserName.ToLower() == normalizedUserName);
        }
    }
}
