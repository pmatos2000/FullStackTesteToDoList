using ToDo.Repositories.Entitys;

namespace ToDo.Repositories.Model
{
    public class User
    {
        public long Id { get; set; }
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<TodoItem>? Tasks { get; set; }
        public ICollection<Category>? Categories { get; set; }
    }
}
