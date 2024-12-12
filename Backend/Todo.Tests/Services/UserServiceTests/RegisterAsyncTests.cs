using Moq;
using Todo.Tests.Mocks;
using ToDo.Repositories.Interfaces;
using ToDo.Services.Interfaces;
using ToDo.Services.Services;

namespace Todo.Tests.Services.UserServiceTests
{
    public class RegisterAsyncTests
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
        public async Task UserNameExists()
        {
            var userName = MockEntity.MockUser.UserName;
            var password = Constants.PASSWORD;

            mockUserRepositorie
                .Setup(m => m.VerifyUserNameAsync(It.IsAny<string>()))
                .ReturnsAsync(true);

            var result = await userService.RegisterAsync(userName, password);

            Assert.That(result, Is.False);

            mockUserRepositorie
                .Verify(m => m.VerifyUserNameAsync(userName), Times.Once());

            mockUserRepositorie.VerifyNoOtherCalls();
        }

        [Test]
        public async Task RegisterSucess()
        {
            var userName = MockEntity.MockUser.UserName;
            var password = Constants.PASSWORD;

            mockUserRepositorie
                .Setup(m => m.VerifyUserNameAsync(It.IsAny<string>()))
                .ReturnsAsync(false);

            var result = await userService.RegisterAsync(userName, password);

            Assert.That(result, Is.True);

            mockUserRepositorie
                .Verify(m => m.VerifyUserNameAsync(userName), Times.Once());
            mockUserRepositorie
                .Verify(m => m.RegisterAsync(userName, It.IsAny<string>()), Times.Once());

            mockUserRepositorie.VerifyNoOtherCalls();
        }







    }
}
