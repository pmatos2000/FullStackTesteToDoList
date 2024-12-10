namespace ToDo.Services.Dto
{
    public record CategoryDto
    {
        public long Id { get; init; }
        public required string Name { get; init; }
    }
}
