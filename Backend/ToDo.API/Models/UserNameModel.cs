namespace ToDo.API.Models
{
    public record UserNameModel
    {
        /// <summary>
        /// O nome de usuário a ser verificado.
        /// </summary>
        public required string UserName { get; init; }
    }
}
