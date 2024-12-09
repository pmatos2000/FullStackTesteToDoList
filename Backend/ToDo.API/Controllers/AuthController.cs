using Microsoft.AspNetCore.Mvc;
using ToDo.API.Models;
using ToDo.Repositories.Model.Entity;
using ToDo.Services.Interfaces;
using ToDo.Shared.Constants;

namespace ToDo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Verifica se um nome de usuário existe no banco de dados.
        /// </summary>
        /// <returns>True se o nome de usuário existir; caso contrário, False.</returns>
        /// <response code="200">Retorna true se o nome de usuário existir; caso contrário, false.</response>
        /// <response code="400">Se a validação falhar.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("verify-username")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> VerifyUserNameAsync([FromQuery] UserNameModel model)
        {
            var result = await userService.VerifyUserNameAsync(model.UserName);
            return Ok(result);
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="user">O usuário a ser criado.</param>
        /// <returns>O usuário criado.</returns> 
        /// <response code="200">Retorna sucesso se o usiario foi criado.</response>
        /// <response code="400">Se a validação falhar.</response>
        /// <response code="409">Usuário já existe.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterModel user)
        {
            var result = await userService.RegisterAsync(user.UserName, user.Password);

            if (result)
            {
                return Ok(new
                {
                    Message = Messages.SUCCESS_NEW_USER
                });
            }

            return Conflict( new
            {
                Message = Messages.ERRO_USER_CONFLICT
            });
        }

        /// <summary>
        /// Realiza o login de um usuário.
        /// </summary>
        /// <param name="loginModel">Modelo contendo o nome de usuário e a senha.</param>
        /// <returns>JWT e o nome de usuário.</returns>
        /// <response code="200">Retorna o JWT e o nome de usuário se a autenticação for bem-sucedida.</response>
        /// <response code="400">Erros de validação ou credenciais incorretas.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResponseModel), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginUserModel loginModel)
        {
            var loginResult = await userService.LoginAsync(loginModel.UserName, loginModel.Password);

            if (loginResult.Success)
            {
                return Ok(loginResult);
            }

            return BadRequest(new
            {
                Message = loginResult.ErrorMessage,
            });
        }
    }
}
