using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.Contratos;
using Aplicacion.ManejadorError;
using Dominio.Entidades;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Seguridad
{
    public class CrearUsuario
    {
        public class ejecuta : IRequest<UsuarioData>
        {
            public string? Nombre { get; set; }
            public string? Apellido { get; set; }
            public string? Email { get; set; }
            public string? Password { get; set; }
            public string? UserName { get; set; }

        }

        public class EjecutaValidacion : AbstractValidator<ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
                RuleFor(x => x.UserName).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<ejecuta, UsuarioData>
        {
            private readonly SeriesOnlineContext _contexto;
            private readonly UserManager<Usuario> _userManager;
            private readonly IJwtGenerador _jwtGenerador;
            public Manejador(SeriesOnlineContext context, UserManager<Usuario> userManager, IJwtGenerador jwtGenerador)
            {
                _contexto = context;
                _userManager = userManager;
                _jwtGenerador = jwtGenerador;
            }
            public async Task<UsuarioData> Handle(ejecuta request, CancellationToken cancellationToken)
            {
                var existe = await _contexto.Users.Where(x => x.Email == request.Email).AnyAsync();
                if(existe){
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new {mensaje = "El Email ya esta en uso"});
                }

                var existeUserName = await _contexto.Users.Where(x => x.UserName == request.UserName).AnyAsync();
                if(existeUserName){
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new {mensaje = "El usuario ya se registro anteriormente"});

                }

                 var usuario = new Usuario{
                    NombreCompleto = request.Nombre + " " + request.Apellido,
                    Email = request.Email,
                    UserName = request.UserName
                };

                var resultado = await _userManager.CreateAsync(usuario, request.Password!);
               
                
                if(resultado.Succeeded){
                    return new UsuarioData{
                        NombreCompleto = usuario.NombreCompleto,
                        Token = _jwtGenerador.CrearToken(usuario, null!),
                        Username = usuario.UserName,
                        Email = usuario.Email
                    };
                }
                throw new Exception("No se pudo agregar el nuevo usuario");
            }
        }
    }
}