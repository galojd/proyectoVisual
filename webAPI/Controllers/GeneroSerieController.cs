using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Mantenimiento.Generos;
using Aplicacion.Mantenimiento.GeneroSeries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    public class GeneroSerieController : Micontrollerbase
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(NuevoGeneroSerie.ejecuta data){
            return await Mediator.Send(data);
        }
        
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<List<GeneroDto>>> Get(){
            //se llama al mediador para que me devuelva la data de comentario
            return await Mediator.Send(new MostrarGenero.ejecuta());
        }
    }
}