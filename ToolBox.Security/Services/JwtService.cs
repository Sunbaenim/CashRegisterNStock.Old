using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Security.Configurations;
using ToolBox.Security.Models;

namespace ToolBox.Security.Services
{
    public class JwtService
    {
        private readonly JwtSecurityTokenHandler _handler;
        private readonly JwtConfig _config;

        public JwtService(JwtSecurityTokenHandler handler, JwtConfig config)
        {
            _handler = handler;
            _config = config;
        }

        private SecurityKey CreateSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Signature));
        }

        public string CreateToken(IBasePayload payload)
        {
            JwtSecurityToken jwt = new JwtSecurityToken(_config.Issuer, _config.Audience, new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, payload.Identifier)
            }, DateTime.Now, _config.Validity == 0 ? null : DateTime.Now.AddMilliseconds(_config.Validity),
            new SigningCredentials(CreateSecurityKey(), SecurityAlgorithms.HmacSha512));
            return _handler.WriteToken(jwt);
        }

        public ClaimsPrincipal GetClaims(string token)
        {
            return _handler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateAudience = _config.ValidateAudience,
                ValidateIssuer = _config.ValidateIssuer,
                ValidateLifetime = _config.ValidateLifeTime,
                ValidateIssuerSigningKey = true,
                ValidAudience = _config.Audience,
                ValidIssuer = _config.Issuer,
                IssuerSigningKey = CreateSecurityKey()
            }, out SecurityToken securityToken);
        }
    }
}
