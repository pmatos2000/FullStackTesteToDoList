using Microsoft.AspNetCore.Mvc;
using ToDo.API.Models;
using ToDo.Repositories.Model.Entity;
using ToDo.Services.Interfaces;

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
        [HttpGet("verify-username")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> VerifyUserName([FromQuery] UserNameModel model)
        {
            var result = await userService.VerifyUserName(model.UserName);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            return Ok();
        }
    }
}
