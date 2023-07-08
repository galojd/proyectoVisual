using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Mantenimiento.Comentarios;
using AutoMapper;
using Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Mantenimiento.Series
{
    public class ConsultaSerieLimitado
    {
        public class ListaSerie : IRequest<List<SerieDto>> { }

        public class manejador : IRequestHandler<ListaSerie, List<SerieDto>>
        {
            private readonly SeriesOnlineContext _contexto;
            private readonly  IMapper _mapper;
            

            public manejador(SeriesOnlineContext contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
               
            }

            public async Task<List<SerieDto>> Handle(ListaSerie request, CancellationToken cancellationToken)
            {
                var serie = await _contexto.Serie!
                            .Include(x => x.TextoComentario)
                            .Include(x => x.NumeroCapitulo)
                            .Include(x => x.Generoserie)!.ThenInclude(x => x.genero)
                            .OrderByDescending(x => x.SerieId)
                            .Take(10) 
                            .ToListAsync();

                foreach (var s in serie)
                {
                    var capitulos = await _contexto.Capitulo!
                                    .Where(x => x.SerieId == s.SerieId)
                                    .OrderBy(x => x.NumeroCapitulo) // Orden ascendente por el número de capítulo dentro de cada serie
                                    .ToListAsync();

                    var comentarios = await _contexto.Comentario!
                                    .Where(x => x.CapituloId == null && x.SerieId == s.SerieId)
                                    .ToListAsync();

                    s.NumeroCapitulo = capitulos;
                    s.TextoComentario = comentarios;
                }

    
                var seriedto = _mapper.Map<List<Serie>, List<SerieDto>>(serie);
                
                return seriedto;
            }
        }


    }
}