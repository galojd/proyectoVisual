using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;

namespace Aplicacion.Mantenimiento.Comentarios
{
    public class EliminarComentario
    {
        public class ejecuta : IRequest{
            public Guid Codigocomentario{get;set;}
        }

        public class manejador : IRequestHandler<ejecuta>
        {
            private readonly SeriesOnlineContext _contexto;
            public manejador(SeriesOnlineContext context)
            {
                _contexto = context;
            }
            public async Task<Unit> Handle(ejecuta request, CancellationToken cancellationToken)
            {
                var comentario = await _contexto.Comentario!.FindAsync(request.Codigocomentario);
                if(comentario == null){
                    //throw new Exception("El instructor no existe");
                    //aqui se comunica cpn el manejadro excepcion
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el comentario a eliminar"});
                }
                _contexto.Remove(comentario);
                
                var resultado = await _contexto.SaveChangesAsync();
                if(resultado > 0){
                    return Unit.Value;
                }
                throw new Exception("No se pudo eliminar el registro");
            }
        }
    }
}