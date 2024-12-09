using Microsoft.EntityFrameworkCore;

using ToDo.Repositories.Interfaces;
using ToDo.Repositories.Model;

namespace ToDo.Repositories.Repositories
{
    public class UserRepositorie : IUserRepositorie
    {
        private readonly AppDbContext appDbContext;

        public UserRepositorie(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Task<UserLogin?> GetUserLoginByNameAsync(string userName)
        {
            return appDbContext.Users
                .Where(x => x.UserName == userName)
                .Select(x => new UserLogin
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    PasswordHash = x.PasswordHash,
                })
                .FirstOrDefaultAsync();
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
