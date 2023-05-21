using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Contratos;
using Dominio.Entidades;
using Microsoft.IdentityModel.Tokens;

namespace Seguridad.TokenSeguridad
{
    public class JwtGenerador : IJwtGenerador
    {
        public string CrearToken(Usuario usuario, List<string> roles)
        {
            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.NameId, usuario.UserName!)               
            };

            if (roles != null){
                foreach(var rol in roles){
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }
            }

            //se crea las credenciales de acceso
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Otra prueba de token basico"));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokendescripcion = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = credenciales

            };

            //se crea el token
            var tokenmanejador = new JwtSecurityTokenHandler();
            //el token se basa en la definicion de descripcion para poder ser creado
            var token = tokenmanejador.CreateToken(tokendescripcion);

            return tokenmanejador.WriteToken(token);
        }
    }
}