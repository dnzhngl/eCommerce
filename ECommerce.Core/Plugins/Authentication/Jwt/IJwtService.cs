using ECommerce.Core.Plugins.Authentication.Models;

namespace ECommerce.Core.Plugins.Authentication.Jwt
{
    public interface IJwtService
    {
        TokenInfo CreateToken(JwtCreateModel model);
    }
}