using ToDo.Repositories.Entitys;

namespace ToDo.Repositories.Model
{
    public class TodoItem
    {
        public long Id { get; init; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }
        public long UserId { get; init; }
        public User? User { get; init; }
        public long? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
