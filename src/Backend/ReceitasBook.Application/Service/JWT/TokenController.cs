using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasBook.Application.Service.JWT
{
    public class TokenController
    {
        private readonly double _expirytime;
        private readonly string _secretkey;

        public TokenController(double expirytime, string secretkey)
        {
            _expirytime = expirytime;
            _secretkey = secretkey;
        }

        public string GerarToken(string username,string email)
        {
            var claims = new List<Claim>
        {
            new Claim("username",username),

            new Claim("email",email)
        };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_expirytime),
                SigningCredentials = new SigningCredentials(Simetrickey(), SecurityAlgorithms.HmacSha256Signature)
            };
            var SecurityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(SecurityToken);
        }

        private SymmetricSecurityKey Simetrickey()
        {
            var symmetrickey = Convert.FromBase64String(_secretkey);
            return new SymmetricSecurityKey(symmetrickey);
        }

        public void ValidarToken(string Token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var parametrosValidacao = new TokenValidationParameters
            {
                RequireExpirationTime = true,
                IssuerSigningKey = Simetrickey(),
                ClockSkew = new TimeSpan(0),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
            tokenHandler.ValidateToken(Token, parametrosValidacao, out _);
        }
    }
}
