using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Repositories.Model;

namespace ToDo.Repositories.Entitys
{
    public record Category
    {
        public long Id { get; init; }
        public required string Name {  get; init; } 
        public long UserId { get; init; }
        public User? User { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
        public ICollection<TodoItem>? Tasks { get; init; }
    }
}
