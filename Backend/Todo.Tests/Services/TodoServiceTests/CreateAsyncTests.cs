using Moq;
using Todo.Tests.Mocks;
using ToDo.Repositories.Interfaces;
using ToDo.Repositories.Model;
using ToDo.Services.Services;

namespace Todo.Tests.Services.TodoServiceTests
{
    public class CreateAsyncTests
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
        public async Task CreateSucess()
        {
            var todoCreate = MockDto.TodoCreateOne;

            mockTodoRepositorie
                .Setup(m => m.CreateAsync(It.IsAny<TodoItem>()))
                .ReturnsAsync(MockConstants.TASK_ID_ONE);

            var result = await todoService.CreateAsync(todoCreate);

            Assert.That(result, Is.EqualTo(MockConstants.TASK_ID_ONE));

            mockTodoRepositorie.Verify
            (
                m => m.CreateAsync
                (
                    It.Is<TodoItem>(a => MockEntity.CompareTodoItem(a, MockEntity.TodoItemOne)
                )
            ), Times.Once);

            mockTodoRepositorie.VerifyNoOtherCalls();
        }
    }
}
