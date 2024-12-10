
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Models;
using ToDo.Services.Interfaces;
using ToDo.Shared.Constants;

namespace ToDo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(IConfiguration configuration, ICategoryService categoryService) : base(configuration)
        {
            this.categoryService = categoryService;
        }


        /// <summary>
        /// Cria uma nova categoria para o usuário logado.
        /// </summary>
        /// <param name="model">Modelo contendo o nome da categoria.</param>
        /// <returns>Retorna um status indicando o resultado da operação.</returns>
        /// <response code="200">Retorna se a categoria foi criada com sucesso.</response>
        /// <response code="400">Retorna se a validação dos dados falhar.</response>
        /// <response code="401">Retorna se as credenciais estiverem incorretas ou o usuário não estiver autenticado.</response>
        /// <response code="409">Retorna se a categoria já existe para este usuário.</response>
        /// <response code="500">Retorna se ocorrer um erro interno do servidor.</response>
        [HttpPost("create")]
        [ProducesResponseType(typeof(CategoryModel), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(MessageResponseModel), 401)]
        [ProducesResponseType(typeof(MessageResponseModel), 409)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryModel model)
        {
            var userId = GetUsetIdFromJwtToken();
            if (userId == null)
            {
                return Unauthorized(new MessageResponseModel(Messages.ERRO_INVALID_CREDENTIALS));
            }

            var result = await categoryService.CreateAsync(userId.Value, model.CategoryName);
            if (result == null)
            {
                return Conflict(new MessageResponseModel(Messages.ERRO_CATEGORY_CONFLICT));
            }
            return Ok(new CategoryModel
            {
                Id = result.Id,
                Name = result.Name,
            });
        }

    }
}
