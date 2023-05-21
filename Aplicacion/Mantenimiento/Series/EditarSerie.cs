using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;

namespace Aplicacion.Mantenimiento.Series
{
    public class EditarSerie
    {
        public class ejecuta : IRequest
        {
            public Guid SerieId{get;set;}
            public string? Nombre { get; set; }
            public string? Descripcion { get; set; }
            public string? Imagen { get; set; }

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
                var serie = await contexto.Serie!.FindAsync(request.SerieId);
                if (serie == null)
                {
                    //throw new Exception("El curso no existe");
                    //aqui se comunica cpn el manejadro excepcion
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "no se pudo encontrar la serie a editar" });
                }

                serie.Nombre = request.Nombre ?? serie.Nombre;
                serie.Descripcion = request.Descripcion ?? serie.Descripcion;
                serie.Imagen = request.Imagen ?? serie.Imagen;

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