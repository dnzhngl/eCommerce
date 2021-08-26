using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EShop.Core.Helpers;
using EShop.Core.Plugins.Authentication.Models;
using Microsoft.IdentityModel.Tokens;

namespace EShop.Core.Plugins.Authentication.Jwt
{
    public class JwtService :IJwtService
    {
        private readonly JwtOption _jwtOption;

        public JwtService(JwtOption jwtOption)
        {
            _jwtOption = jwtOption;
        }

        public TokenInfo CreateToken(JwtCreateModel model)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.SecurityKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var token = CreateJwtSecurityToken(model, signingCredentials);
            return new TokenInfo
            {
                Token = token,
                RefreshToken = RandomHelper.Mixed(32),
                TokenExpiration = DateTime.Now.AddMinutes(_jwtOption.AccessTokenExpiration),
                RefreshTokenExpiration = DateTime.Now.AddMinutes(_jwtOption.RefreshTokenExpiration)
            };
        }
        
        
        private string CreateJwtSecurityToken(JwtCreateModel model, SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                _jwtOption.Issuer,
                _jwtOption.Audience,
                expires: DateTime.Now.AddMinutes(_jwtOption.AccessTokenExpiration),
                notBefore: DateTime.Now,
                claims: new List<Claim>
                {
                    new("Id" ,model.Id.ToString()),
                    new("FullName", model.FullName),
                    new("IsSuperVisor", model.IsSuperVisor.ToString()),
                    
                }
                , signingCredentials: signingCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}