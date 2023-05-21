using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Contratos;
using Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Aplicacion.Seguridad
{
    public class UsuarioActual
    {
        public class Ejecuta : IRequest<UsuarioData>
        {
            
        }

        public class manejador : IRequestHandler<Ejecuta, UsuarioData>
        {
            private readonly UserManager<Usuario> _userManager;

            private readonly IJwtGenerador _jwtGenerador;
            
            private readonly IUsuarioSesion _iusuariosesion;
            
            public manejador(UserManager<Usuario> userManager, IJwtGenerador jwtGenerador, IUsuarioSesion iusuariosesion)
            {
                _userManager = userManager;
                _jwtGenerador = jwtGenerador;
                _iusuariosesion = iusuariosesion;
            }

            public async Task<UsuarioData> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                //busco al usuario particular
                var usuario = await _userManager.FindByNameAsync(_iusuariosesion.ObtenerUsuarioSesion());
                var resultadoroles = await _userManager.GetRolesAsync(usuario!);
                var listaroles = new List<string>(resultadoroles);
                
                return new UsuarioData{
                    id = usuario!.Id,
                    NombreCompleto = usuario!.NombreCompleto,
                    Username = usuario.UserName,
                    Token = _jwtGenerador.CrearToken(usuario, listaroles),
                    Email = usuario.Email,
                    Imagen = null
                };
            }
        }

        
    }
}