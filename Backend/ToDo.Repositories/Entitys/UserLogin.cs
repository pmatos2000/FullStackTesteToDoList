namespace ToDo.Repositories.Model
{
    public record UserLogin
    {
        public long Id { get; init; }
        public required string UserName { get; init; }
        public required string PasswordHash { get; init; }
    }
}
