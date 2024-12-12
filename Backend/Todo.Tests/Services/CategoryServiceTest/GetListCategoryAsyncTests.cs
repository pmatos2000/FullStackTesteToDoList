using Moq;
using Todo.Tests.Mocks;
using ToDo.Repositories.Interfaces;
using ToDo.Services.Services;

namespace Todo.Tests.Services.CategoryServiceTest
{
    public class GetListCategoryAsyncTests
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
        public async Task GetListSucess()
        {
            var userId = Constants.USER_ID_ONE;

            mockCategoryRepositorie
                .Setup(m => m.GetListCategoryAsync(It.IsAny<long>()))
                .ReturnsAsync(MockEntity.ListCategoryOne);

            var result = await categoryService.GetListCategoryAsync(userId);

            Assert.That(result, Is.EqualTo(MockDto.ListCategoryOne));

            mockCategoryRepositorie
                .Verify(m => m.GetListCategoryAsync(Constants.USER_ID_ONE), Times.Once);

            mockCategoryRepositorie
                .VerifyNoOtherCalls();
        }
    }
}
