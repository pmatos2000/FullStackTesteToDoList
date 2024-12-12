﻿using Moq;
using NUnit.Framework;
using ToDo.Repositories.Interfaces;
using ToDo.Services.Interfaces;
using ToDo.Services.Services;
using Todo.Tests.Mocks;
using ToDo.Repositories.Entitys.Models;
using ToDo.Shared.Constants;
using NUnit.Framework.Legacy;

namespace Todo.Tests.Services.UserServiceTests
{
    public class LoginAsyncTests
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
        public async Task UserNotFound()
        {
            var userName = Entity.MockUser.UserName;
            var password = Constants.PASSWORD;

            mockUserRepositorie
                .Setup(m => m.GetUserLoginByNameAsync(It.IsAny<string>()))
                .ReturnsAsync((UserLogin?)null);

            var result = await userService.LoginAsync(userName, password);

            Assert.That(result.Success, Is.False);
            Assert.That(result.ErrorMessage, Is.EqualTo(Messages.ERRO_USER_NOT_EXIT));

            mockUserRepositorie
                .Verify(m => m.GetUserLoginByNameAsync(userName), Times.Once());

            mockUserRepositorie.VerifyNoOtherCalls();
        }

        [Test]
        public async Task PasswordError()
        {
            var userName = Entity.MockUserLogin.UserName;
            var password = "123456";

            mockUserRepositorie
                .Setup(m => m.GetUserLoginByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(Entity.MockUserLogin);

            var result = await userService.LoginAsync(userName, password);

            Assert.That(result.Success, Is.False);
            Assert.That(result.ErrorMessage, Is.EqualTo(Messages.ERRO_PASSWORD_INVALID));

            mockUserRepositorie
                .Verify(m => m.GetUserLoginByNameAsync(userName), Times.Once());

            mockUserRepositorie.VerifyNoOtherCalls();
        }

        [Test]
        public async Task LoginSucess()
        {
            var userName = Entity.MockUserLogin.UserName;
            var password = Constants.PASSWORD;

            mockUserRepositorie
                .Setup(m => m.GetUserLoginByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(Entity.MockUserLogin);

            var result = await userService.LoginAsync(userName, password);

            Assert.That(result.Success, Is.True);
            Assert.That(result.ErrorMessage, Is.EqualTo(String.Empty));
            Assert.That(result.UserName, Is.EqualTo(userName));
            Assert.That(result.UserId, Is.EqualTo(Entity.MockUserLogin.Id));


            mockUserRepositorie
                .Verify(m => m.GetUserLoginByNameAsync(userName), Times.Once());

            mockUserRepositorie.VerifyNoOtherCalls();
        }
    }
}
