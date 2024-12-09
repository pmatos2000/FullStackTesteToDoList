using ToDo.Repositories.Model;

namespace ToDo.Repositories.Interfaces
{
    public interface IUserRepositorie
    {
        public Task<bool> VerifyUserNameAsync(string userName);
        public Task RegisterAsync(string userName, string passwordHash);
        public Task<UserLogin?> GetUserLoginByNameAsync(string userName);
    }
}
