using ToDo.Repositories.Entitys;

namespace ToDo.Repositories.Model
{
    public class User
    {
        public long Id { get; init; }
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; }
        public DateTime CreatedAt { get; init; }
        public ICollection<TodoItem>? Tasks { get; init; }
        public ICollection<Category>? Categories { get; init; }
    }
}
