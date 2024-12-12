using ToDo.Repositories.Entitys;
using ToDo.Repositories.Entitys.Models;
using ToDo.Repositories.Model;

namespace Todo.Tests.Mocks
{
    public static class MockEntity
    {
        public static User MockUser { get; } = new User
        {
            UserName = "UserName",
            PasswordHash = Constants.HASH_PASSWORD_SUCESS
        };

        public static UserLogin MockUserLogin { get; } = new UserLogin
        {
            Id = 1,
            UserName = "UserName",
            PasswordHash = Constants.HASH_PASSWORD_SUCESS
        };

        public static Category CategoryOne { get; } = new Category
        {
            Id = Constants.CATEGORY_ID_UM,
            UserId = Constants.USER_ID_ONE,
            Name = Constants.CATEGORY_NAME_ONE
        };

        public static Category CategoryTwo { get; } = new Category
        {
            Id = Constants.CATEGORY_ID_TWO,
            UserId = Constants.USER_ID_ONE,
            Name = Constants.CATEGORY_NAME_TWO
        };

        public static IEnumerable<Category> ListCategoryOne { get; } = [CategoryOne, CategoryTwo];
    }
}
