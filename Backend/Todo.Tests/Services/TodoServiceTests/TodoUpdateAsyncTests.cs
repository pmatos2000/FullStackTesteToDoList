using Moq;
using Todo.Tests.Mocks;
using ToDo.Repositories.Interfaces;
using ToDo.Repositories.Model;
using ToDo.Services.Services;

namespace Todo.Tests.Services.TodoServiceTests
{
    internal class TodoUpdateAsyncTests
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
            var todoId = MockConstants.TASK_ID_ONE;
            var todoCreate = MockDto.TodoCreateOne;

            mockTodoRepositorie
                .Setup(m => m.TodoUpdateAsync(It.IsAny<long>(), It.IsAny<TodoItem>()))
                .ReturnsAsync(MockConstants.TASK_ID_ONE);

            var result = await todoService.TodoUpdateAsync(todoId, todoCreate);

            Assert.That(result, Is.EqualTo(MockConstants.TASK_ID_ONE));

            mockTodoRepositorie.Verify
            (
                m => m.TodoUpdateAsync
                (
                    todoId,
                    It.Is<TodoItem>(a => MockEntity.CompareTodoItem(a, MockEntity.TodoItemOne)
                )
            ), Times.Once);

            mockTodoRepositorie.VerifyNoOtherCalls();
        }
    }
}
