using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Aplicacion.Seguridad
{
    public class RolNuevo
    {
        public class Ejecuta : IRequest{
            public String? Nombre {get;set;}
        }

        public class ValidaEjecuta : AbstractValidator<Ejecuta>
        {
            public ValidaEjecuta()
            {
                RuleFor(x => x.Nombre).NotEmpty();
            }
        }

        public class manejador : IRequestHandler<Ejecuta>
        {
            private readonly RoleManager<IdentityRole> _roleManager;
            public manejador(RoleManager<IdentityRole> roleManager)
            {
                _roleManager = roleManager;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var role = await _roleManager.FindByNameAsync(request.Nombre!);
                if(role != null){
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new {mensaje = "Ya existe el rol"});
                }

                var resultado = await _roleManager.CreateAsync(new IdentityRole(request.Nombre!) );
                if(resultado.Succeeded){
                    return Unit.Value;
                }

                throw new Exception("No se pudo guardar el rol");
            }
        }
    }
}