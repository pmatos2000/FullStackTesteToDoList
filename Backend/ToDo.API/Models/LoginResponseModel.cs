namespace ToDo.API.Models
{
    public record LoginResponseModel
    {
        public required string UserName { get; set; }
        public required string JwtToken { get; set; }
    }
}
