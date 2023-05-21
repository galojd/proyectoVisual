using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Entidades;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Mantenimiento.Series
{
    public class ConsultaSerie
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
                //.Include(x => x.UsuariodeSerie)!.ThenInclude(x => x.UserName)
                .Include(x => x.Generoserie)!.ThenInclude(x => x.genero).ToListAsync();
                /*.Include(x => x.NumeroCapitulo)
                .Include(x => x.TextoComentario)
                .Include(x => x.Generoserie)!.ThenInclude(x => x.genero)
                .Include(x => x.UsuariodeSerie)!.ThenInclude(x => x.usuario)*/
                
                var seriedto = _mapper.Map<List<Serie>, List<SerieDto>>(serie);
                return seriedto;
            }
        }


    }
}