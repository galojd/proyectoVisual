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

namespace Aplicacion.Mantenimiento.Capitulos
{
    public class Muestracodnumcap
    {
        public class ejecuta : IRequest<List<CapituloDto>> {
            public Guid? codserie{get;set;}
            public int? NumeroCapitulo { get; set; }
         }


        public class manejador : IRequestHandler<ejecuta, List<CapituloDto>>
        {
            private readonly SeriesOnlineContext _contexto;
            private readonly  IMapper _mapper;
            public manejador(SeriesOnlineContext contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<List<CapituloDto>> Handle(ejecuta request, CancellationToken cancellationToken)
            {
                var serie = await _contexto.Serie!
                               .FirstOrDefaultAsync(x => x.SerieId == request.codserie);

                if (serie == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "No se encontró la serie que buscaba" });
                }


                var capitulo = await _contexto.Capitulo!
                                        .Where(x => x.NumeroCapitulo == request.NumeroCapitulo && x.SerieId == request.codserie)
                                        .Include(x => x.TextoComentario)
                                        .ToListAsync();
                
                if(capitulo == null){
                    //throw new Exception("El curso no existe");
                    //aqui se comunica cpn el manejadro excepcion
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "No se encontro el capitulo que buscaba"});
                }

                var caitulodto = _mapper.Map<List<Capitulo>, List<CapituloDto>>(capitulo);

                // Agregar el nombre de la serie al resultado
                caitulodto.ForEach(c => c.Nombreserie = serie.Nombre);
                return caitulodto;
            }
        }
    }
}