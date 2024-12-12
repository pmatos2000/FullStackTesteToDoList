using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Tests.Mocks;
using ToDo.Repositories.Interfaces;
using ToDo.Services.Services;

namespace Todo.Tests.Services.TodoServiceTests
{
    public class GetListTodoAsync
    {
        private Mock<ITodoRepositorie> mockTodoRepositorie;

        private TodoService todoService;

        [SetUp]
        public void Init()
        {
            mockTodoRepositorie = new Mock<ITodoRepositorie>();
            todoService = new TodoService(mockTodoRepositorie.Object);
        }

        [Test]
        public async Task GetListTodoSucess()
        {
            var userId = MockConstants.USER_ID_ONE;

            mockTodoRepositorie
                .Setup(m => m.GetListTodoAsync(It.IsAny<long>(), It.IsAny<long?>()))
                .ReturnsAsync(MockEntity.ListTodoItem);

            var result = await todoService.GetListTodoAsync(userId, null);

            Assert.That(result, Is.EqualTo(MockDto.ListTodoItem));
        }
    }
}
