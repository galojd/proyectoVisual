using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Persistencia;
using Microsoft.EntityFrameworkCore;
using Aplicacion.ManejadorError;
using System.Net;
using Dominio.Entidades;

namespace Aplicacion.Mantenimiento.Capitulos
{
    public class buscacapserie
    {
        public class Listacapporserie : IRequest<List<CapituloDto>> {
            public Guid? codserie{get;set;}
         }


        public class manejador : IRequestHandler<Listacapporserie, List<CapituloDto>>
        {
            private readonly SeriesOnlineContext _contexto;
            private readonly  IMapper _mapper;
            public manejador(SeriesOnlineContext contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<List<CapituloDto>> Handle(Listacapporserie request, CancellationToken cancellationToken)
            {
                var capitulo = await _contexto.Capitulo!
                                        .Where(x => x != null && x.SerieId == request.codserie)
                                        .ToListAsync();
                
                if(capitulo == null){
                    //throw new Exception("El curso no existe");
                    //aqui se comunica cpn el manejadro excepcion
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "No se encontro la serie que buscaba"});
                }

                var caitulodto = _mapper.Map<List<Capitulo>, List<CapituloDto>>(capitulo);
                return caitulodto;
            }
        }
    }
}