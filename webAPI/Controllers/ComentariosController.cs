using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Mantenimiento.Comentarios;
using Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    public class ComentariosController : Micontrollerbase
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(NuevoComentario.ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpGet("buscarcomenatarioserie/{serieid}")]
        //[Authorize]
        public async Task<ActionResult<List<Comentario>>> mostrarserie(Guid serieid){
            //se llama al mediador para que me devuelva la data de comentario
            return await Mediator.Send(new MostrarComentarioSeries.ejecuta{serieid = serieid});
        }

        [HttpGet("buscarcomenatariocapitulo/{capituloid}")]
        //[Authorize]
        public async Task<ActionResult<List<Comentario>>> mostrarcapitulo(Guid capituloid){
            //se llama al mediador para que me devuelva la data de comentario
            return await Mediator.Send(new MostrarComentariosCapitulos.ejecuta{capituloid = capituloid});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
            //ubica el curso por id y lo manda para ejecutar el cambio
            return await Mediator.Send(new EliminarComentario.ejecuta{ Codigocomentario = id});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarComentario.ejecuta data){
            //ubica el curso por id y lo manda para ejecutar el cambio
            data.ComentarioId = id;
            return await Mediator.Send(data);
            
        } 

        
        
    }
}