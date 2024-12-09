using Microsoft.IdentityModel.Tokens;
using System.Text;
using ToDo.Shared.Constants;

namespace ToDo.API.Extension
{
    public static class ConfigurationExtension
    {
        public static SymmetricSecurityKey GetSymmetricKey(this IConfiguration configuration)
        {
            var secretKey = configuration["Secret:Key"] ?? "";

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException(Messages.ERRO_SECRET_KEY_NOT_APPSETTINGS);
            }
            if (secretKey.Length < 16)
            {
                throw new InvalidOperationException(Messages.ERRO_SECRET_KEY_SIZE);
            }
            var key = Encoding.ASCII.GetBytes(secretKey);

            return new SymmetricSecurityKey(key);
        }
    }
}
