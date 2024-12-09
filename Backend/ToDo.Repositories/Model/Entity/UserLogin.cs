using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Repositories.Model.Entity
{
    public record UserLogin
    {
        public long Id { get; init; }
        public required string UserName { get; init; }
        public required string PasswordHash { get; init; }
    }
}
