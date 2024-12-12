using Moq;
using ToDo.Repositories.Interfaces;
using ToDo.Services.Interfaces;
using ToDo.Services.Services;

namespace Todo.Tests.Services.UserServiceTests
{
    public class VerifyUserNameAsyncTests
    {
        private Mock<IUserRepositorie> mockUserRepositorie;

        private IUserService userService;

        [SetUp]
        public void Init()
        {
            mockUserRepositorie = new Mock<IUserRepositorie>();
            userService = new UserService(mockUserRepositorie.Object);
        }

        [Test]
        public async Task UserNameNotFoud()
        {
            var userName = "NAME_TEST";

            mockUserRepositorie
                .Setup(m => m.VerifyUserNameAsync(It.IsAny<string>()))
                .ReturnsAsync(false);

            var result = await userService.VerifyUserNameAsync(userName);

            Assert.That(result, Is.False);

            mockUserRepositorie
                .Verify(m => m.VerifyUserNameAsync(userName), Times.Once());

            mockUserRepositorie.VerifyNoOtherCalls();
        }

        [Test]
        public async Task UserNameExists()
        {
            var userName = "NAME_TEST";

            mockUserRepositorie
                .Setup(m => m.VerifyUserNameAsync(It.IsAny<string>()))
                .ReturnsAsync(true);

            var result = await userService.VerifyUserNameAsync(userName);

            Assert.That(result, Is.True);

            mockUserRepositorie
                .Verify(m => m.VerifyUserNameAsync(userName), Times.Once());

            mockUserRepositorie.VerifyNoOtherCalls();
        }






    }
}
