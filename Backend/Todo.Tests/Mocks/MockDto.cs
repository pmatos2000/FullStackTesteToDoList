using ToDo.Repositories.Entitys;
using ToDo.Services.Dto;

namespace Todo.Tests.Mocks
{
    public static class MockDto
    {
        public static CategoryDto CategoryOne = new CategoryDto
        {
            Id = MockConstants.CATEGORY_ID_ONE,
            Name = MockConstants.CATEGORY_NAME_ONE
        };

        public static CategoryDto CategoryTwo = new CategoryDto
        {
            Id = MockConstants.CATEGORY_ID_TWO,
            Name = MockConstants.CATEGORY_NAME_TWO
        };

        public static IEnumerable<CategoryDto> ListCategoryOne { get; } = [CategoryOne, CategoryTwo];

        public static TodoCreateDto TodoCreateOne { get; } = new TodoCreateDto
        {
            UserId = MockConstants.USER_ID_ONE,
            Title = MockConstants.TASK_TITLE_ONE,
            Description = MockConstants.TASK_DESCRIPTION_ONE,
            IsCompleted = MockConstants.TASK_IS_COMPLETED_ONE,
            CategoryId = MockConstants.CATEGORY_ID_ONE,
        };
    }
}
