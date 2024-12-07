using Microsoft.AspNetCore.Mvc;
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
        /// <param name="userName">O nome de usuário a ser verificado.</param>
        /// <returns>True se o nome de usuário existir; caso contrário, False.</returns>
        /// <response code="200">Retorna true se o nome de usuário existir; caso contrário, false.</response>
        [HttpGet("verify-username")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<bool>> VerifyUserName([FromQuery] string userName)
        {
            var result = await userService.VerifyUserName(userName);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            return Ok();
        }
    }
}
