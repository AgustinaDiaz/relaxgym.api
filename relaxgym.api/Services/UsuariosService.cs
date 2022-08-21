using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using relaxgym.api.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace relaxgym.api.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IConfiguration _configuration;
        public UsuariosService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public UserToken Authenticate(Usuario usuario)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            byte[] tokenKey = Encoding.UTF8.GetBytes(_configuration["Authentication:Key"]);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.PrimarySid, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                    new Claim(ClaimTypes.GivenName, string.Concat(usuario.Apellido, " ", usuario.Nombre)),
                    new Claim(ClaimTypes.Role, usuario.Rol.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Authentication:ExpirationToken"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserToken { Token = tokenHandler.WriteToken(token) };
        }
    }
}
