using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Mantenimiento.UsuarioSeries
{
    public class EliminarUsuarioSerie
    {
        public class ejecuta : IRequest{
            public string? usuarioid{get;set;}

            public Guid serieid{get;set;}
        }

        /*public class EjecutaValidacion : AbstractValidator<ejecuta>{
            public EjecutaValidacion(){
                RuleFor(x => x.usuarioid).NotEmpty();
                RuleFor(x => x.serieid).NotEmpty();
            }

        }*/

        public class manejador : IRequestHandler<ejecuta>
        {
            private readonly SeriesOnlineContext _contexto;
            public manejador(SeriesOnlineContext context)
            {
                _contexto = context;
            }
            public async Task<Unit> Handle(ejecuta request, CancellationToken cancellationToken)
            {
                var usuarioserie = await _contexto.UsuarioSerie!.Where(x => x.SerieId == request.serieid && x.UsuarioId == request.usuarioid ).FirstAsync();
                if(usuarioserie == null){
                    //throw new Exception("El instructor no existe");
                    //aqui se comunica cpn el manejadro excepcion
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar la Serie a eliminar"});
                }
                _contexto.UsuarioSerie!.Remove(usuarioserie);
                
                var resultado = await _contexto.SaveChangesAsync();
                if(resultado>0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo eliminar el registro");
            }
        }
    }
}