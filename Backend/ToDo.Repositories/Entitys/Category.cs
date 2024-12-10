using ToDo.Repositories.Model;

namespace ToDo.Repositories.Entitys
{
    public class Category
    {
        public long Id { get; init; }
        public required string Name { get; set; }
        public long UserId { get; init; }
        public User? User { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<TodoItem>? Tasks { get; init; }
    }
}
