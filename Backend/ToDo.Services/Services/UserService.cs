using ToDo.Repositories.Interfaces;
using ToDo.Services.Dto;
using ToDo.Services.Interfaces;
using ToDo.Shared.Constants;
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

        public async Task<LoginUserDto> LoginAsync(string userName, string password)
        {
            var loginUser = await userRepositorie.GetUserLoginByNameAsync(userName);

            if (loginUser == null)
            {
                return new LoginUserDto
                {
                    Success = false,
                    ErrorMessage = Messages.ERRO_USER_NOT_EXIT,
                };
            }
            if (Password.VerifyPassword(password, loginUser.PasswordHash))
            {
                return new LoginUserDto
                {
                    Success = true,
                    UserId = loginUser.Id,
                    UserName = loginUser.UserName,
                };
            }
            return new LoginUserDto
            {
                Success = false,
                ErrorMessage = Messages.ERRO_PASSWORD_INVALID,
            };
        }
    }
}
