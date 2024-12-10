namespace ToDo.API.Models
{
    public record TodoCreateModel
    {
        public required string Title { get; init; }
        public required string Description { get; init; }
        public bool IsCompleted { get; init; }
        public long? CategoryId { get; init; }
    }
}
