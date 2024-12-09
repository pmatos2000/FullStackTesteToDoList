using ToDo.Services.Dto;

namespace ToDo.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> VerifyUserNameAsync(string userName);
        public Task<bool> RegisterAsync(string userName, string password);
        public Task<LoginUserDto> LoginAsync(string userName, string password);
    }
}
