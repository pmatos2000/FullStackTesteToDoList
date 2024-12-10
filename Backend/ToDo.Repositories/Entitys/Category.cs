using ToDo.Repositories.Model;

namespace ToDo.Repositories.Entitys
{
    public class Category
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public long UserId { get; set; }
        public User? User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<TodoItem>? Tasks { get; set; }
    }
}
