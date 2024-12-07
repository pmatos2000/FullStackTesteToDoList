namespace ToDo.API.Models
{
    public record UserModel
    {
        /// <summary>
        /// Nome de usuário
        /// </summary>
        public required string UserName { get; init; }

        /// <summary>
        /// Senha do usuário
        /// </summary>
        public required string Password { get; init; }
    }
}