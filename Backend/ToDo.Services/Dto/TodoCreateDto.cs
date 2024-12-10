namespace ToDo.Services.Dto
{
    public record TodoCreateDto
    {
        public long UserId { get; init; }
        public required string Title { get; init; }
        public required string Description { get; init; }
        public bool IsCompleted { get; init; }
        public long? CategoryId { get; init; }
    }
}
