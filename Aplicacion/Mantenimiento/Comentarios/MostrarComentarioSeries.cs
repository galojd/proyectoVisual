using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Mantenimiento.Comentarios
{
    public class MostrarComentarioSeries
    {
        public class ejecuta : IRequest<List<Comentario>>{
            public Guid serieid{get;set;}
        }

        public class Manejador : IRequestHandler<ejecuta, List<Comentario>>
        {
            private readonly SeriesOnlineContext _contexto;

            public Manejador(SeriesOnlineContext contexto)
            {
                _contexto = contexto;
            }
            
            public async Task<List<Comentario>> Handle(ejecuta request, CancellationToken cancellationToken)
            {
                var comentarios = await _contexto.Comentario!.Where(x => x.CapituloId == null && x.SerieId == request.serieid).ToListAsync();

                return comentarios;
            }
        }
    }
}