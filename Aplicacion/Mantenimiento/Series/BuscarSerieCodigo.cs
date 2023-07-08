using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using AutoMapper;
using Dominio.Entidades;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Mantenimiento.Series
{

    //LIKE(CONTAINS) '%TEXTO%'
    //startsWith 'texto%'
    //endsWith
    public class BuscarSerieCodigo
    {
        public class ListaSerieporcodigo : IRequest<List<SerieDto>> {
            public Guid? codigo{get;set;}
         }

        public class manejador : IRequestHandler<ListaSerieporcodigo, List<SerieDto>>
        {
            private readonly SeriesOnlineContext _contexto;
            private readonly  IMapper _mapper;
            public manejador(SeriesOnlineContext contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<List<SerieDto>> Handle(ListaSerieporcodigo request, CancellationToken cancellationToken)
            {
                var serie = await _contexto.Serie!.Where(x => x.SerieId == request.codigo)
                .Include(x => x.TextoComentario)
                .Include(x => x.NumeroCapitulo)
                //.Include(x => x.UsuariodeSerie)!.ThenInclude(x => x.UserName)
                .Include(x => x.Generoserie)!.ThenInclude(x => x.genero)
                .ToListAsync();
            
                if(serie == null){
                    //throw new Exception("El curso no existe");
                    //aqui se comunica cpn el manejadro excepcion
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "No se encontro la serie que buscaba"});
                }

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