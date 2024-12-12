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

        public static TodoItemDto TodoItemTwo { get; } = new TodoItemDto
        {
            Id = MockConstants.TASK_ID_TWO,
            Title = "Title",
            Description = "Description",
            IsCompleted = false,
            CategoryId = MockConstants.CATEGORY_ID_TWO,
            CreatedAt = MockConstants.DATE_CREATED_AT_ONE,
            UpdatedAt = MockConstants.DATE_UPDATED_AT_ONE
        };

        public static TodoItemDto TodoItemThree { get; } = new TodoItemDto
        {
            Id = MockConstants.TASK_ID_THREE,
            Title = "Title",
            Description = "Description",
            IsCompleted = false,
            CategoryId = null,
            CreatedAt = MockConstants.DATE_CREATED_AT_ONE,
            UpdatedAt = MockConstants.DATE_UPDATED_AT_ONE
        };

        public static IEnumerable<TodoItemDto> ListTodoItem { get; } = [TodoItemTwo, TodoItemThree];
    }
}
