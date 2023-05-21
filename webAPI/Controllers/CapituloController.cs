using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Mantenimiento.Capitulos;
using Persistencia.DapperConexion.Paginacion;

namespace webAPI.Controllers
{
    public class CapituloController : Micontrollerbase
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(NuevoCapitulo.ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<CapituloDto>>> Get(){
            //se llama al mediador para que me devuelva la data de comentario
            return await Mediator.Send(new ConsultaCapitulo.Ejecuta());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
            //ubica el curso por id y lo manda para ejecutar el cambio
            return await Mediator.Send(new EliminarCapitulo.ejecuta{ Codigocapitulo = id});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarCapitulo.ejecuta data){
            //ubica el curso por id y lo manda para ejecutar el cambio
            data.CapituloId = id;
            return await Mediator.Send(data);
            
        }

        [HttpPost("report")]
        public async Task<ActionResult<PaginacionModel>> Report(Mostrarultimocap.ejecuta data){
            return await Mediator.Send(data);

        } 
        
    }
}