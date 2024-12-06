using Microsoft.AspNetCore.Mvc;
using ToDo.Repositories.Model.Entity;

namespace ToDo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            return Ok();
        }
    }
}
