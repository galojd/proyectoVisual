using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio;
using Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Aplicacion.Seguridad
{
    public class ObternerRolPorId
    {
         public class Ejecuta : IRequest<List<String>>{
            public string? Username {get;set;}
        }

        public class manejador : IRequestHandler<Ejecuta, List<String>>
        {
            private readonly UserManager<Usuario> _usermanager;
            private readonly RoleManager<IdentityRole> _rolemanager;
            public manejador(UserManager<Usuario> usermanager, RoleManager<IdentityRole> rolemanager)
            {
                _usermanager = usermanager;
                _rolemanager = rolemanager;
            }

            public async Task<List<string>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                
                var user = await _usermanager.FindByNameAsync(request.Username!);
                if(user == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "El usuario no existe"});
                }

               var resultado= await _usermanager.GetRolesAsync(user);
               return new List<string>(resultado);
            }
        }


    }
}