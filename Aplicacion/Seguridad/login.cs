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

namespace Aplicacion.Seguridad
{
    public class login
    {
        public class Ejecuta : IRequest<UsuarioData>
        {
            public string? Email { get; set; }
            public string? Password { get; set; }

        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta, UsuarioData>
        {
            private readonly UserManager<Usuario> _usermanager;
            private readonly SignInManager<Usuario> _signInManager;
            private readonly IJwtGenerador _jwtGenerador;

            public Manejador(UserManager<Usuario> usermanager, SignInManager<Usuario> signInManager, IJwtGenerador jwtGenerador)
            {
                _usermanager = usermanager;
                _signInManager = signInManager;
                _jwtGenerador = jwtGenerador;
            }


            public async Task<UsuarioData> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                //se verifica que el usuario exista
                var usuario = await _usermanager.FindByEmailAsync(request.Email!);
                if (usuario == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.Unauthorized, new {mensaje = "No se encontro el Email"});
                }

                var resultado = await _signInManager.CheckPasswordSignInAsync(usuario, request.Password!, false);
                var resultadoroles = await _usermanager.GetRolesAsync(usuario);
                var listaroles = new List<string> (resultadoroles);

                if (resultado.Succeeded)
                {
                    return new UsuarioData
                    {
                        id = usuario.Id,
                        NombreCompleto = usuario.NombreCompleto,
                        Token = _jwtGenerador.CrearToken(usuario, listaroles),
                        Username = usuario.UserName,
                        Email = usuario.Email,
                        Imagen = null
                    };
                }
                throw new ManejadorExcepcion(HttpStatusCode.Unauthorized);
            }
        }
    }
}