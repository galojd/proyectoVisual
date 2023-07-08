using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Mantenimiento.UsuarioSeries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    public class UsuarioSerieController : Micontrollerbase
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(NuevoUsuarioSerie.ejecuta data){
            return await Mediator.Send(data);

        }

        [HttpPost("Eliminar")]
        public async Task<ActionResult<Unit>> Crear(EliminarUsuarioSerie.ejecuta data){
            return await Mediator.Send(data);

        }
        [HttpGet("listar/{usuario}")]
        public async Task<ActionResult<List<UsuarioDto>>> buscaporusuario(String usuario){
            //se llama al mediador para que me devuelva la data de curso
            return await Mediator.Send(new MostrarSerieUsuario.Ejecuta{usuarioId = usuario});
        }        
    }
}