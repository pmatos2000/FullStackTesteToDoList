namespace ToDo.API.Models
{
    public record UserRegisterModel
    {
        public required string UserName { get; init; }
        public required string Password { get; init; }
    }
}