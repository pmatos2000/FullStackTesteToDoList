using Microsoft.AspNetCore.Mvc;
using ToDo.API.Models;
using ToDo.Services.Dto;
using ToDo.Services.Interfaces;
using ToDo.Shared.Constants;

namespace ToDo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : BaseController
    {
        private readonly ITodoService todoService;

        public TodoController(IConfiguration configuration, ITodoService todoService) : base(configuration)
        {
            this.todoService = todoService;
        }


        /// <summary>
        /// Cria uma nova tarefa para o usuário logado.
        /// </summary>
        /// <param name="model">Modelo contendo os dados da tarefa a ser criada.</param>
        /// <returns>Retorna id da tarefa criada</returns>
        /// <response code="201">Retorna o id da tarefa criada.</response>
        /// <response code="400">Retorna se a validação dos dados falhar.</response>
        /// <response code="401">Retorna se as credenciais estiverem incorretas ou o usuário não estiver autenticado.</response>
        /// <response code="500">Retorna se ocorrer um erro interno do servidor.</response>
        [HttpPost("create")]
        [ProducesResponseType(typeof(IdResponseModel), 201)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(MessageResponseModel), 401)]
        public async Task<IActionResult> CreateTaskAsync([FromBody] TodoCreateModel model)
        {
            var userId = GetUsetIdFromJwtToken();
            if (userId == null)
            {
                return Unauthorized(new MessageResponseModel(Messages.ERRO_INVALID_CREDENTIALS));
            }

            var todoId = await todoService.CreateAsync(new TodoCreateDto
            {
                Title = model.Title,
                Description = model.Description,
                IsCompleted = model.IsCompleted,
                CategoryId = model.CategoryId,
                UserId = userId.Value,
            });

            return Ok(new IdResponseModel(todoId));
        }

    }
}
