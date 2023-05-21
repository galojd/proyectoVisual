using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.Contratos;
using Aplicacion.ManejadorError;
using AutoMapper;
using Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Mantenimiento.UsuarioSeries
{
    public class MostrarSerieUsuario
    {
        public class Ejecuta : IRequest<List<UsuarioDto>>{
            public string? usuarioId{get;set;}
            
        }

        public class manejador : IRequestHandler<Ejecuta, List<UsuarioDto>>
        {
            private readonly SeriesOnlineContext _contexto;
            private readonly  IMapper _mapper;
            public manejador(SeriesOnlineContext contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<List<UsuarioDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var usuario = await _contexto.Usuario!.Where(x => x.Id == request.usuarioId!)
                .Include(x => x.UsuariodeSerie)!.ThenInclude(x => x.serie).ToListAsync();

                if(usuario == null){
                    //throw new Exception("El curso no existe");
                    //aqui se comunica cpn el manejadro excepcion
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "No se encontro el usuario que buscaba"});
                }
                var usuariodto = _mapper.Map<List<Usuario>, List<UsuarioDto>>(usuario);
                return usuariodto;
            }
        }
    }
}