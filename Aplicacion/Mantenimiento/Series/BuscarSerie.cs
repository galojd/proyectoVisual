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
    public class BuscarSerie
    {
        public class ListaSeriepornombre : IRequest<List<SerieDto>> {
            public string? nombreserie{get;set;}
         }

        public class manejador : IRequestHandler<ListaSeriepornombre, List<SerieDto>>
        {
            private readonly SeriesOnlineContext _contexto;
            private readonly  IMapper _mapper;
            public manejador(SeriesOnlineContext contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<List<SerieDto>> Handle(ListaSeriepornombre request, CancellationToken cancellationToken)
            {
                var serie = await _contexto.Serie!.Where(x => x.Nombre!.Contains(request.nombreserie!))
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

                var seriedto = _mapper.Map<List<Serie>, List<SerieDto>>(serie);
                return seriedto;
            }
        }
    }
}