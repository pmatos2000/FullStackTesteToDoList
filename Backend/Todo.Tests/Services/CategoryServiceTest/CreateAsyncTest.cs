using Moq;
using ToDo.Repositories.Interfaces;
using ToDo.Services.Services;
using Todo.Tests.Mocks;
using ToDo.Services.Dto;

namespace Todo.Tests.Services.CategoryServiceTest
{
    public class CreateAsyncTest
    {
        private Mock<ICategoryRepositorie> mockCategoryRepositorie;

        private CategoryService categoryService;


        [SetUp]
        public void Init()
        {
            mockCategoryRepositorie = new Mock<ICategoryRepositorie>();
            categoryService = new CategoryService(mockCategoryRepositorie.Object);
        }

        [Test]
        public async Task Conflict()
        {
            var userId = Constants.USER_ID_ONE;
            var categoryName = Constants.CATEGORY_NAME_ONE;

            mockCategoryRepositorie
                .Setup(m => m.VerifyCategoryNameAsync(It.IsAny<long>(), It.IsAny<string>()))
                .ReturnsAsync(true);

            var result = await categoryService.CreateAsync(userId, categoryName);

            Assert.That(result, Is.Null);

            mockCategoryRepositorie
                .Verify(m => m.VerifyCategoryNameAsync(Constants.USER_ID_ONE, Constants.CATEGORY_NAME_ONE), Times.Once);

            mockCategoryRepositorie
                .VerifyNoOtherCalls();
        }

        [Test]
        public async Task CreateSucess()
        {
            var userId = Constants.USER_ID_ONE;
            var categoryName = Constants.CATEGORY_NAME_ONE;

            mockCategoryRepositorie
                .Setup(m => m.VerifyCategoryNameAsync(It.IsAny<long>(), It.IsAny<string>()))
                .ReturnsAsync(false);

            mockCategoryRepositorie
                .Setup(m => m.CreateCategoryAsync(It.IsAny<long>(), It.IsAny<string>()))
                .ReturnsAsync(MockEntity.CategoryOne);

            var result = await categoryService.CreateAsync(userId, categoryName);

            Assert.That(result, Is.EqualTo(MockDto.CategoryOne));

            mockCategoryRepositorie
                .Verify(m => m.VerifyCategoryNameAsync(Constants.USER_ID_ONE, Constants.CATEGORY_NAME_ONE), Times.Once);

            mockCategoryRepositorie
                .Verify(m => m.CreateCategoryAsync(Constants.USER_ID_ONE, Constants.CATEGORY_NAME_ONE), Times.Once);

            mockCategoryRepositorie
                .VerifyNoOtherCalls();
        }


    }
}
