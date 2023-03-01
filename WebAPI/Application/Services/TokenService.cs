using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Domain.Models;
using WebAPI.Infra.Data;

namespace WebAPI.Application.Services
{
    public class TokenService
    {
        public static object GenerateToken(Employee employee) //Informa qual parametros sao passados pelo payload. nesse caso, um funcionario a ser autenticado
        {
            var key = Encoding.ASCII.GetBytes(Key.Secret); //importando a chave privada do token e criptografando ela

            //Configurar o token. O que vai ter no payload, qual tempo pra expirar, etc...
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                      new Claim("employeeId", employee.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;

        }
    }
}
