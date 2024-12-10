﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDo.API.Models;
using ToDo.Repositories.Model;
using ToDo.Services.Dto;
using ToDo.Services.Interfaces;
using ToDo.Shared.Constants;

namespace ToDo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : BaseController
    {
        private readonly ITodoService todoService;

        public TaskController(IConfiguration configuration, ITodoService todoService) : base(configuration)
        {
            this.todoService = todoService;
        }


        /// <summary>
        /// Cria uma nova tarefa para o usuário logado.
        /// </summary>
        /// <param name="model">Modelo contendo os dados da tarefa a ser criada.</param>
        /// <returns>Retorna um status indicando o resultado da operação.</returns>
        /// <response code="200">Retorna o id da tarefa criada.</response>
        /// <response code="400">Retorna se a validação dos dados falhar.</response>
        /// <response code="401">Retorna se as credenciais estiverem incorretas ou o usuário não estiver autenticado.</response>
        /// <response code="500">Retorna se ocorrer um erro interno do servidor.</response>
        [HttpPost("create")]
        [ProducesResponseType(typeof(IdResponseModel), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(MessageResponseModel), 401)]
        public async Task<IActionResult> CreateTodoAsync([FromBody] TodoCreateModel model)
        {
            var userId = GetUsetIdFromJwtToken();
            if (userId == null)
            {
                return Unauthorized(new MessageResponseModel(Messages.ERRO_INVALID_CREDENTIALS));
            }

            var todoCreateDto = ConvertTodoCreateModelToDto(model, userId.Value);
            var todoId = await todoService.CreateAsync(todoCreateDto);

            return Ok(new IdResponseModel(todoId));
        }


        /// <summary>
        /// Atualiza uma tarefa existente para o usuário logado.
        /// </summary>
        /// <param name="id">O id da tarefa a ser atualizada.</param>
        /// <param name="model">Modelo contendo os dados atualizados da tarefa.</param>
        /// <returns>Retorna um status indicando o resultado da operação.</returns>
        /// <response code="200">Retorna se a tarefa foi atualizada com sucesso.</response>
        /// <response code="400">Retorna se a validação dos dados falhar.</response>
        /// <response code="401">Retorna se as credenciais estiverem incorretas ou o usuário não estiver autenticado.</response>
        /// <response code="404">Retorna se a tarefa não for encontrada.</response>
        /// <response code="500">Retorna se ocorrer um erro interno do servidor.</response>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateTodoAsync([FromBody] TodoUpdateModel model)
        {
            var userId = GetUsetIdFromJwtToken();
            if (userId == null)
            {
                return Unauthorized(new MessageResponseModel(Messages.ERRO_INVALID_CREDENTIALS));
            }

            var todoCreateDto = ConvertTodoCreateModelToDto(model, userId.Value);
            var todoId = await todoService.TodoUpdateAsync(model.Id, todoCreateDto);

            if (todoId == null) return NotFound();

            return Ok(new MessageResponseModel(Messages.SUCESS_TODO_UPDATE));
        }


        /// <summary>
        /// Atualiza o status de conclusão de uma tarefa existente para o usuário logado.
        /// </summary>
        /// <param name="id">O id da tarefa a ser atualizada.</param>
        /// <param name="isCompleted">Novo status de conclusão da tarefa.</param>
        /// <returns>Retorna um status indicando o resultado da operação.</returns>
        /// <response code="200">Retorna se o status da tarefa foi atualizado com sucesso.</response>
        /// <response code="401">Retorna se as credenciais estiverem incorretas ou o usuário não estiver autenticado.</response>
        /// <response code="404">Retorna se a tarefa não for encontrada.</response>
        /// <response code="500">Retorna se ocorrer um erro interno do servidor.</response>
        [HttpPatch("update-completed")]
        public async Task<IActionResult> TodoUpdateCompletionStatusAsync(long id, bool isCompleted)
        {
            var userId = GetUsetIdFromJwtToken();
            if (userId == null)
            {
                return Unauthorized(new MessageResponseModel(Messages.ERRO_INVALID_CREDENTIALS));
            }

            var todoId = await todoService.TodoUpdateCompletionStatusAsync(userId.Value, id, isCompleted);

            if (todoId == null) return NotFound();

            return Ok(new MessageResponseModel(Messages.SUCESS_TODO_UPDATE_STATUS));
        }


        /// <summary>
        /// Recupera uma tarefa existente para o usuário logado pelo ID fornecido.
        /// </summary>
        /// <param name="id">O ID da tarefa a ser retornada.</param>
        /// <returns>Retorna a tarefa correspondente ao ID fornecido ou um status indicando o resultado da operação.</returns>
        /// <response code="200">A tarefa foi encontrada e retornada com sucesso.</response>
        /// <response code="401">As credenciais estão incorretas ou o usuário não está autenticado.</response>
        /// <response code="404">A tarefa não foi encontrada.</response>
        /// <response code="500">Ocorreu um erro interno no servidor.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MessageResponseModel), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTodoAsync(long id)
        {
            var userId = GetUsetIdFromJwtToken();
            
            if (userId == null)
                return Unauthorized(new MessageResponseModel(Messages.ERRO_INVALID_CREDENTIALS));
            
            var todo = await todoService.GetTodoAsync(userId.Value, id);

            if (todo == null) return NotFound();

            var todoModel = ConvertTodoItemDtoToModel(todo);

            return Ok(todoModel);
        }

        private static TodoCreateDto ConvertTodoCreateModelToDto(TodoCreateModel todoCreateDto, long userId)
        {
            return new TodoCreateDto
            {
                Title = todoCreateDto.Title,
                Description = todoCreateDto.Description,
                IsCompleted = todoCreateDto.IsCompleted,
                CategoryId = todoCreateDto.CategoryId,
                UserId = userId
            };
        }

        private static TodoItemModel ConvertTodoItemDtoToModel(TodoItemDto item)
        {
            return new TodoItemModel
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted,
                CategoryId = item.CategoryId,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt
            };
        }
    }
}
