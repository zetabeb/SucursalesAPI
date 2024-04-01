using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SucursalesAPI.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using SucursalesAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace SucursalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string secretKey;
        public AutenticacionController(DataContext context, IConfiguration config)
        {
            _context = context;
            secretKey = config.GetSection("settings").GetSection("secretkey").ToString();
        }

        [HttpPost]
        [Route("Validar")]
        public IActionResult Validar([FromBody] LoginModel request)
        {
            var usuario = _context.Usuarios.SingleOrDefault(u => u.email == request.correo && u.clave == request.clave);

            if (usuario != null)
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.email),
                    new Claim(ClaimTypes.Role, usuario.rol)
                };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };
                

                var tokenHandler = new JwtSecurityTokenHandler();                
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
                string tokenCreated = tokenHandler.WriteToken(tokenConfig);

                return StatusCode(StatusCodes.Status200OK, new { token = tokenCreated });
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = " " });
            }
        }
    }
}
