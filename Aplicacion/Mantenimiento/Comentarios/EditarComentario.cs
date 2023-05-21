using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Mantenimiento.Comentarios
{
    public class EditarComentario
    {
        public class ejecuta : IRequest
        {
            public Guid ComentarioId{get;set;}
            public string? ComentarioTexto { get; set; }
            
        }

        public class manejador : IRequestHandler<ejecuta>
        {
            private readonly SeriesOnlineContext contexto;
            public manejador(SeriesOnlineContext context)
            {
                contexto = context;
            }
            public async Task<Unit> Handle(ejecuta request, CancellationToken cancellationToken)
            {
                var comentario = await contexto.Comentario!.FindAsync(request.ComentarioId);;
                if (comentario == null)
                {
                    //throw new Exception("El curso no existe");
                    //aqui se comunica cpn el manejadro excepcion
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "no se pudo encontrar el comentario a editar" });
                }

                comentario.ComentarioTexto = request.ComentarioTexto ?? comentario.ComentarioTexto;
                comentario.Fechacreacion   = DateTime.UtcNow;

                var resultado = await contexto.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo modificar el registro");
            }
        }
    }
}