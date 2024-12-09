namespace ToDo.API.Models
{
    public record CreateCategoryModel
    {
        public required string CategoryName { get; init; }
    }
}
