using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Aula09.Models;

namespace Aula09.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(Login login)
        {
            if (login.Usuario == "admin" && login.Senha == "123")
            {
                var token = GerarToken(login.Usuario);
                return Ok(new { token });
            }

            return Unauthorized();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Acesso autorizado!");
        }

        private string GerarToken(string usuario)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                "minha-chave-super-secreta-com-mais-de-32-caracteres"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, usuario)
        };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
