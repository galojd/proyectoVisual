using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.Contratos;
using Aplicacion.ManejadorError;
using Dominio;
using Dominio.Entidades;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Seguridad
{
    public class UsuarioActualizar
    {
        public class Ejecuta : IRequest<UsuarioData>
        {
            public string? Nombre { get; set; }

            public string? Apellidos { get; set; }

            public string? Email { get; set; }

            public string? Password { get; set; }

            public string? Username { get; set; }

        }

        public class ValidaEjecuta : AbstractValidator<Ejecuta>
        {
            public ValidaEjecuta()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellidos).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
                RuleFor(x => x.Username).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta, UsuarioData>
        {
            private readonly SeriesOnlineContext _context;
            private readonly UserManager<Usuario> _usermanager;
            //trae tambien a la interface que me permite crear un nuevo token
            private readonly IJwtGenerador _jwtGenerador;
            //esto es para el password que esta cifrado
            private readonly IPasswordHasher<Usuario> _passwoordhasher;
            public Manejador(SeriesOnlineContext context, UserManager<Usuario> usermanager, IJwtGenerador jwtGenerador, IPasswordHasher<Usuario> passwoordhasher)
            {
                _context = context;
                _usermanager = usermanager;
                _jwtGenerador = jwtGenerador;
                _passwoordhasher = passwoordhasher;
            }
            public async Task<UsuarioData> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var usuarioiden = await _usermanager.FindByNameAsync(request.Username!);
                if (usuarioiden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El usuario con este username no existe" });
                }
                var resultado = await _context.Users.Where(x => x.Email == request.Email && x.UserName != request.Username).AnyAsync();
                if(resultado ){
                    throw new ManejadorExcepcion(HttpStatusCode.InternalServerError, new { mensaje = "Este Email pertenece a otro usuario" });
                }

                usuarioiden.NombreCompleto = request.Nombre + " " + request.Apellidos;
                usuarioiden.Email = request.Email;
                usuarioiden.PasswordHash = _passwoordhasher.HashPassword(usuarioiden, request.Password!);

                var resultadoupdate = await _usermanager.UpdateAsync(usuarioiden);
                var resultadoRoles = await _usermanager.GetRolesAsync(usuarioiden);
                var roles = new List<string> (resultadoRoles);

                if(resultadoupdate.Succeeded){
                    return new UsuarioData{
                        NombreCompleto = usuarioiden.NombreCompleto,
                        Email = usuarioiden.Email,
                        Username = usuarioiden.UserName,
                        Token = _jwtGenerador.CrearToken(usuarioiden, roles)
                    };
                }

                throw new Exception("No se pudo actualizar el usuario");

            }
        }
    }
}