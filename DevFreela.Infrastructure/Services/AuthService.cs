using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Services
{
    public class AuthService : IAuthService
    {

        public readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ComputerSha256Hash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())//Inicializando o método do sha256 Create
            {
                //ComputeHash - retorna byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));


                //Converte byte array para string
                StringBuilder builder = new StringBuilder();//concatenação de string


                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));// 2x faz com que sseja convertido em representação hexadecimal
                }


                return builder.ToString();
            }
        }

      

        public string GenerationJwtToken(string email, string role)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("email", email),
                new Claim(" role", role)
            };

            var issuer = _configuration["JwtToken:issuer"];
            var audience = _configuration["JwtToken:audience"];
            var key = _configuration["JwtToken:key"];

            var keySymmetric = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var signature = new SigningCredentials(keySymmetric, SecurityAlgorithms.HmacSha256);
            var timeExpires = DateTime.Now.AddHours(Convert.ToDouble(_configuration["JwtToken:expires"]));
            var token = new JwtSecurityToken(issuer: issuer, 
                audience: audience, 
                claims: claims, 
                expires: timeExpires, 
                signingCredentials:signature)
                ;


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
