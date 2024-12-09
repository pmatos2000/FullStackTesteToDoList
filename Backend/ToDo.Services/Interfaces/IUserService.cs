using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
