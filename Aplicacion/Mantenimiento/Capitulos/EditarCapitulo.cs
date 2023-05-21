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
    public class EditarCapitulo
    {
        public class ejecuta : IRequest
        {
            public Guid CapituloId { get; set; }
            public int? NumeroCapitulo { get; set; }
            public string? NombreCapitulo { get; set; }
            public string? CapituloUrl { get; set; }
            public string? imagenurl { get; set; }
            public int? Temporada { get; set; }

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
                var capitulo = await contexto.Capitulo!.FindAsync(request.CapituloId);;
                if (capitulo == null)
                {
                    //throw new Exception("El curso no existe");
                    //aqui se comunica cpn el manejadro excepcion
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "no se pudo encontrar el capitulo a editar" });
                }

                //var porsi = await contexto.Capitulo.Where(x => x.NumeroCapitulo = request.NumeroCapitulo )

                capitulo.NumeroCapitulo     = request.NumeroCapitulo ?? capitulo.NumeroCapitulo;
                capitulo.NombreCapitulo     = request.NombreCapitulo ?? capitulo.NombreCapitulo;
                capitulo.CapituloUrl        = request.CapituloUrl ?? capitulo.CapituloUrl;
                capitulo.imagenurl          = request.imagenurl ?? capitulo.imagenurl;
                capitulo.Temporada          = request.Temporada ?? capitulo.Temporada;
                capitulo.Fechacreacion      = DateTime.UtcNow;

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