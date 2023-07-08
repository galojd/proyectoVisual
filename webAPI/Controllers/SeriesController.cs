using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Mantenimiento.Series;
using Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistencia.DapperConexion.Paginacion;

namespace webAPI.Controllers
{
    //http://localhost:5169/api/Series
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : Micontrollerbase
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(NuevoSeries.ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<List<SerieDto>>> Get(){
            //se llama al mediador para que me devuelva la data de comentario
            return await Mediator.Send(new ConsultaSerie.ListaSerie());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
            //ubica el curso por id y lo manda para ejecutar el cambio
            return await Mediator.Send(new EliminarSerie.ejecuta{ Codigoserie = id});
        } 


        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<SerieDto>>> buscapornombre(string nombre){
            //se llama al mediador para que me devuelva la data de curso
            return await Mediator.Send(new BuscarSerie.ListaSeriepornombre{nombreserie = nombre});
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarSerie.ejecuta data){
            //ubica el curso por id y lo manda para ejecutar el cambio
            data.SerieId = id;
            return await Mediator.Send(data);
            
        }

        [HttpPost("report")]
        public async Task<ActionResult<PaginacionModel>> Report(Paginacionserie.ejecuta data){
            return await Mediator.Send(data);

        }

        [HttpGet("listado")]
        //[Authorize]
        public async Task<ActionResult<List<SerieDto>>> listalimitada(){
            //se llama al mediador para que me devuelva la data de comentario
            return await Mediator.Send(new ConsultaSerieLimitado.ListaSerie());
        }

        [HttpGet("buscalo/{idserie}")]
        public async Task<ActionResult<List<SerieDto>>> buscaporcodigo(Guid idserie){
            //se llama al mediador para que me devuelva la data de curso
            return await Mediator.Send(new BuscarSerieCodigo.ListaSerieporcodigo{codigo = idserie});
        } 
        
    }
}