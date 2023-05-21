using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio;
using Dominio.Entidades;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Aplicacion.Seguridad
{
    public class UsuarioRolEliminar
    {
        public class Ejecuta : IRequest{
            public string? Username{get;set;}
            public string? RolNombre{get;set;}
            
        }

        public class ValidaEjecuta : AbstractValidator<Ejecuta>
        {
            public ValidaEjecuta()
            {
                RuleFor(x => x.Username).NotEmpty();
                RuleFor(x => x.RolNombre).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly UserManager<Usuario> _usermanager;
            private readonly RoleManager<IdentityRole> _rolemanager;

            public Manejador(UserManager<Usuario> usermanager, RoleManager<IdentityRole> rolemanager)
            {
                _usermanager = usermanager;
                _rolemanager = rolemanager;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var role = await _rolemanager.FindByNameAsync(request.RolNombre!);
                if(role == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "El rol no existe"});
                }

                var user = await _usermanager.FindByNameAsync(request.Username!);
                if(user == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "El usuario no existe"});
                }

                var resultado = await _usermanager.RemoveFromRoleAsync(user, request.RolNombre!);
                if(resultado.Succeeded){
                    return Unit.Value;
                }

                throw new Exception("No se pudo eliminar el rol");
            }
        }


    }
}