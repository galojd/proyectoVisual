using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Seguridad;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    public class RollController : Micontrollerbase
    {
        [HttpPost("crear")]
        public async Task<ActionResult<Unit>> Crear(RolNuevo.Ejecuta data){
            return await Mediator.Send(data);

        }

        [HttpDelete("eliminar")]
        public async Task<ActionResult<Unit>> Elimitar(RolEliminar.Ejecuta parametros){
            return await Mediator.Send(parametros);
            
        }

        [HttpGet("lista")]
        public async Task<ActionResult<List<IdentityRole>>> Lista(){
            return await Mediator.Send(new RolLista.Ejecuta());
        }

        [HttpPost("AgregarRolUsuario")]
        public async Task<ActionResult<Unit>> AgregarRolUsuario(UsuarioRolAgregar.Ejecuta data){
            return await Mediator.Send(data);

        }

        [HttpPost("EliminarRolUsuario")]
        public async Task<ActionResult<Unit>> EliminarRolUsuario(UsuarioRolEliminar.Ejecuta parametros){
            return await Mediator.Send(parametros);
            
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<List<string>>> listaPorId(string username){
            return await Mediator.Send(new ObternerRolPorId.Ejecuta{Username = username});
        }
        

    }
}