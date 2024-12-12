using Moq;
using Todo.Tests.Mocks;
using ToDo.Repositories.Interfaces;
using ToDo.Services.Services;

namespace Todo.Tests.Services.TodoServiceTests
{
    public class TodoUpdateCompletionStatusAsyncTests
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
        public async Task UpdateSucess()
        {
            var userId = MockConstants.USER_ID_ONE;
            var todoId = MockConstants.TASK_ID_ONE;
            var isCompleted = MockConstants.TASK_IS_COMPLETED_ONE;

            mockTodoRepositorie
                .Setup(m => m.TodoUpdateCompletionStatusAsync(It.IsAny<long>(), It.IsAny<long>(), It.IsAny<bool>()))
                .ReturnsAsync(MockConstants.TASK_ID_ONE);

            var result = await todoService.TodoUpdateCompletionStatusAsync(userId, todoId, isCompleted);

            Assert.That(result, Is.EqualTo(MockConstants.TASK_ID_ONE));

            mockTodoRepositorie.Verify(
                m => m.TodoUpdateCompletionStatusAsync(userId, todoId, isCompleted), Times.Once);

            mockTodoRepositorie.VerifyNoOtherCalls();
        }
    }
}
