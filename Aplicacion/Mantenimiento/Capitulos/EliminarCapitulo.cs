using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;

namespace Aplicacion.Mantenimiento.Capitulos
{
    public class EliminarCapitulo
    {
        public class ejecuta : IRequest{
            public Guid Codigocapitulo{get;set;}
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
                var comentarioDB = _contexto.Comentario!.Where(x => x.CapituloId == request.Codigocapitulo);
                foreach(var comentario in comentarioDB){
                    _contexto.Comentario!.Remove(comentario);
                }


                var capitulo = await _contexto.Capitulo!.FindAsync(request.Codigocapitulo);
                if(capitulo == null){
                    //throw new Exception("El instructor no existe");
                    //aqui se comunica cpn el manejadro excepcion
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar el capitulo a eliminar"});
                }
                _contexto.Remove(capitulo);
                
                var resultado = await _contexto.SaveChangesAsync();
                if(resultado > 0){
                    return Unit.Value;
                }
                throw new Exception("No se pudo eliminar el registro");


                throw new NotImplementedException();
            }
        }
    }
}