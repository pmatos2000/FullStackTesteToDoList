using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Repositories.Model;

namespace Todo.Tests.Mocks
{
    public static class Entity
    {
        public static User MockUser { get; } = new User
        {
            UserName = "UserName",
            PasswordHash = Constants.HASH_PASSWORD_SUCESS
        };
    }
}
