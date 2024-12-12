using ToDo.Repositories.Entitys;
using ToDo.Repositories.Entitys.Models;
using ToDo.Repositories.Model;
using ToDo.Services.Dto;

namespace Todo.Tests.Mocks
{
    public static class MockEntity
    {
        public static User MockUser { get; } = new User
        {
            UserName = "UserName",
            PasswordHash = MockConstants.HASH_PASSWORD_SUCESS
        };

        public static UserLogin MockUserLogin { get; } = new UserLogin
        {
            Id = 1,
            UserName = "UserName",
            PasswordHash = MockConstants.HASH_PASSWORD_SUCESS
        };

        public static Category CategoryOne { get; } = new Category
        {
            Id = MockConstants.CATEGORY_ID_ONE,
            UserId = MockConstants.USER_ID_ONE,
            Name = MockConstants.CATEGORY_NAME_ONE
        };

        public static Category CategoryTwo { get; } = new Category
        {
            Id = MockConstants.CATEGORY_ID_TWO,
            UserId = MockConstants.USER_ID_ONE,
            Name = MockConstants.CATEGORY_NAME_TWO
        };

        public static IEnumerable<Category> ListCategoryOne { get; } = [CategoryOne, CategoryTwo];

        public static TodoItem TodoItemOne { get; } = new TodoItem
        {
            UserId = MockConstants.USER_ID_ONE,
            Title = MockConstants.TASK_TITLE_ONE,
            Description = MockConstants.TASK_DESCRIPTION_ONE,
            IsCompleted = MockConstants.TASK_IS_COMPLETED_ONE,
            CategoryId = MockConstants.CATEGORY_ID_ONE,
        };

        public static bool CompareTodoItem(TodoItem a, TodoItem b)
        {
            return a.Id == b.Id
                && a.Title == b.Title
                && a.Description == b.Description
                && a.IsCompleted == b.IsCompleted
                && a.CategoryId == b.CategoryId;
        }


        public static TodoItem TodoItemTwo { get; } = new TodoItem
        {
            Id = MockConstants.USER_ID_ONE,
            Title = "Title",
            Description = "Description",
            IsCompleted = false,
            CategoryId = MockConstants.CATEGORY_ID_TWO,
            CreatedAt = MockConstants.DATE_CREATED_AT_ONE,
            UpdatedAt = MockConstants.DATE_UPDATED_AT_ONE,
            UserId = MockConstants.USER_ID_ONE,
        };
    }
}
