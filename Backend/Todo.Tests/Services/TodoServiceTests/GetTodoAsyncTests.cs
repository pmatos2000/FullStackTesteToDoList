using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Tests.Mocks;
using ToDo.Repositories.Interfaces;
using ToDo.Repositories.Model;
using ToDo.Services.Services;

namespace Todo.Tests.Services.TodoServiceTests
{
    public class GetTodoAsyncTests
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
        public async Task NotFound()
        {
            var userId = MockConstants.USER_ID_ONE;
            var taskId = MockConstants.TASK_ID_ONE;

            mockTodoRepositorie
                .Setup(m => m.GetTodoAsync(It.IsAny<long>(), It.IsAny<long>()))
                .ReturnsAsync((TodoItem?)null);

            var result = await todoService.GetTodoAsync(userId, taskId);

            Assert.That(result, Is.Null);

            mockTodoRepositorie
                .Verify(m =>  m.GetTodoAsync(userId, taskId), Times.Once());

            mockTodoRepositorie
                .VerifyNoOtherCalls();

        }

        [Test]
        public async Task GetSucess()
        {
            var userId = MockConstants.USER_ID_ONE;
            var taskId = MockConstants.TASK_ID_ONE;

            mockTodoRepositorie
                .Setup(m => m.GetTodoAsync(It.IsAny<long>(), It.IsAny<long>()))
                .ReturnsAsync(MockEntity.TodoItemTwo);

            var result = await todoService.GetTodoAsync(userId, taskId);

            Assert.That(result, Is.EqualTo(MockDto.TodoItemTwo));

            mockTodoRepositorie
                .Verify(m => m.GetTodoAsync(userId, taskId), Times.Once());

            mockTodoRepositorie
                .VerifyNoOtherCalls();

        }



    }
}
