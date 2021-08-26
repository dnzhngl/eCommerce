using System.Text;
using EShop.Core.Plugins.Authentication.Jwt;
using EShop.Core.Plugins.Authentication.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace EShop.Api.Installers.Services
{
    public class JwtInstaller : IServiceInstaller 
    {
        public void InstallService(IServiceCollection services)
        {
            var jwtOption = new JwtOption
            {
                Audience = "EShop",
                Issuer = "EShop",
                SecurityKey = "F2peYX7865Yk8wztCxg8jzZGF5yEx4vu4TK4mN8DLtsVpnGa3V5jabYjFhGf",
                AccessTokenExpiration = 10,
                RefreshTokenExpiration = 50
            };
            
            
            services.AddSingleton(jwtOption);
            services.AddSingleton<IJwtService, JwtService>();
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = jwtOption.Issuer,
                        ValidAudience = jwtOption.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOption.SecurityKey))
                    };
                });
            
        }

            
    }
}