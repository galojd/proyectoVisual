using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Entidades;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Mantenimiento.Capitulos
{
    public class ConsultaCapituloUltimo
    {
        public class Ejecuta : IRequest<List<CapituloDto>>{}

        public class Manejador : IRequestHandler<Ejecuta, List<CapituloDto>>
        {
            private readonly SeriesOnlineContext _contexto;
            private readonly  IMapper _mapper;

            public Manejador(SeriesOnlineContext contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<List<CapituloDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var capitulo = await _contexto.Capitulo!
                                    .Include(x => x.TextoComentario)
                                    .OrderByDescending(x => x.CapituloId)
                                    .Take(10) 
                                    .ToListAsync();
                var capitulodto = _mapper.Map<List<Capitulo>, List<CapituloDto>>(capitulo);
                return capitulodto;
            }
        }
    }
}