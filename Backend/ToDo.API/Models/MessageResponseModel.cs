namespace ToDo.API.Models
{
    public record MessageResponseModel
    {
        public string Message { get; init; }

        public MessageResponseModel(string message)
        {
            Message = message;
        }
    }
}
