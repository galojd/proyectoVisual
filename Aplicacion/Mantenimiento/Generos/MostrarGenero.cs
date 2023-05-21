using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Entidades;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Mantenimiento.Generos
{
    public class MostrarGenero
    {
        public class ejecuta : IRequest<List<GeneroDto>>{}

        public class manejador : IRequestHandler<ejecuta, List<GeneroDto>>
        {
            private readonly SeriesOnlineContext _contexto;
            private readonly  IMapper _mapper;

            public manejador(SeriesOnlineContext contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }


            public async Task<List<GeneroDto>> Handle(ejecuta request, CancellationToken cancellationToken)
            {
                var genero = await _contexto.Genero!.ToListAsync();
                var generodto = _mapper.Map<List<Genero>, List<GeneroDto>>(genero);
                return generodto;
            }
        }
    }
}