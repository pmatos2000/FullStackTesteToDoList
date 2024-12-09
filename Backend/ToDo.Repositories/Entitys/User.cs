namespace ToDo.Repositories.Model
{
    public record User
    {
        public long Id { get; init; }
        public required string UserName { get; init; }
        public required string PasswordHash { get; init; }
        public DateTime CreatedAt { get; init; }
        public ICollection<TodoItem> Tasks { get; init; } = [];
    }
}
