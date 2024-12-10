using ToDo.Repositories.Entitys;

namespace ToDo.Repositories.Model
{
    public class TodoItem
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long UserId { get; set; }
        public User? User { get; set; }
        public long? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
