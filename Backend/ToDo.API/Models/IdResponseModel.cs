namespace ToDo.API.Models
{
    public record IdResponseModel
    {
        public long Id { get; init; }

        public IdResponseModel(long id)
        {
            Id = id;
        }
    }
}
