namespace ToDo.API.Models
{
    public record LoginUserModel
    {
        public required string UserName { get; init; }
        public required string Password { get; init; }
    }
}
