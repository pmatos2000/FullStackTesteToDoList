namespace ToDo.API.Models
{
    public record TodoUpdateModel : TodoCreateModel
    {
        public int Id { get; init; }
    }
}
