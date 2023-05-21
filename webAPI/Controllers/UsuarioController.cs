using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Mantenimiento.UsuarioSeries;
using Aplicacion.Seguridad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    //Permite que este metodo sea accesible sin el token, ya que es el metodo que me devuelve un token
    [AllowAnonymous]
    public class UsuarioController : Micontrollerbase
    {
        [HttpPost("login")]
        public async Task<ActionResult<UsuarioData>> Login(login.Ejecuta parametros){
            return await Mediator.Send(parametros);

        }

        [HttpPost("Crear")]
        public async Task<ActionResult<UsuarioData>> Crear(CrearUsuario.ejecuta data){
            return await Mediator.Send(data);

        }
        
        // http://localhost:5169/api/Usuario
        [HttpGet]
        public async Task<ActionResult<UsuarioData>> DevolverUsuario(){
            return await Mediator.Send(new UsuarioActual.Ejecuta());

        }

        [HttpPut]
        public async Task<ActionResult<UsuarioData>> Actualizar(UsuarioActualizar.Ejecuta parametros){
            return await Mediator.Send(parametros);

        }

        [HttpGet("buscar/{usuario}")]
        public async Task<ActionResult<List<UsuarioDto>>> buscapornombre(string usuario){
            //se llama al mediador para que me devuelva la data de curso
            return await Mediator.Send(new MostrarSerieUsuario.Ejecuta{usuarioId = usuario});
        }
    }
}