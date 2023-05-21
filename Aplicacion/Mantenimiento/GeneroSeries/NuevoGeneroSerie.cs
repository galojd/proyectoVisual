using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using MediatR;
using Persistencia;

namespace Aplicacion.Mantenimiento.GeneroSeries
{
    public class NuevoGeneroSerie
    {
        public class ejecuta : IRequest
        {
            public Guid GeneroId { get; set; }
            public Guid SerieId { get; set; }
        }

        public class manejador : IRequestHandler<ejecuta>{
            private readonly SeriesOnlineContext _contexto;
            public manejador(SeriesOnlineContext contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(ejecuta request, CancellationToken cancellationToken)
            {
                var generoserie = new GeneroSerie{
                    GeneroId = request.GeneroId,
                    SerieId = request.SerieId

                };

                _contexto.GeneroSerie!.Add(generoserie);

                var resultado = await _contexto.SaveChangesAsync();
                if(resultado > 0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo registrar");
            }
        }
    }
}