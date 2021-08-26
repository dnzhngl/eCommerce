using EShop.Core.Plugins.Authentication.Models;

namespace EShop.Core.Plugins.Authentication.Jwt
{
    public interface IJwtService
    {
        TokenInfo CreateToken(JwtCreateModel model);
    }
}