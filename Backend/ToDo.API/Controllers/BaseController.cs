using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ToDo.API.Extension;

namespace ToDo.API.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
        private readonly IConfiguration configuration;

        private const string CLAIM_USER_ID = "userId";

        public BaseController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected string GenerateJwtToken(long userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(CLAIM_USER_ID, userId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(configuration.GetSymmetricKey(), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor); return tokenHandler.WriteToken(token);
        }

        protected long? GetUsetIdFromJwtToken()
        {
            var claims = GetClaims();
            var userIdClaim = claims
                .Where(c => c.Type == CLAIM_USER_ID)
                .Select(c => c.Value)
                .FirstOrDefault();

            if (long.TryParse(userIdClaim, out long userId))
            {
                return userId;
            }

            return null;
        }

        private string? GetJwtTokenFromRequest()
        {
            var authorizationHeader = HttpContext.Request.Headers.Authorization.FirstOrDefault();
            if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
            {
                return authorizationHeader.Substring("Bearer ".Length).Trim();
            }
            return null;
        }

        private IEnumerable<Claim> GetClaims()
        {
            var token = GetJwtTokenFromRequest();
            if (token == null)
            {
                return [];
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            return jwtToken.Claims;
        }
    }
}
