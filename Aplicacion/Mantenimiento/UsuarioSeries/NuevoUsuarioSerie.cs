using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Mantenimiento.UsuarioSeries
{
    public class NuevoUsuarioSerie
    {
        public class ejecuta : IRequest{
            public string? usuarioid{get;set;}

            public Guid serieid{get;set;}
        }

        public class EjecutaValidacion : AbstractValidator<ejecuta>{
            public EjecutaValidacion(){
                RuleFor(x => x.usuarioid).NotEmpty();
                RuleFor(x => x.serieid).NotEmpty();
            }

        }

        public class manejador : IRequestHandler<ejecuta>
        {
            private readonly SeriesOnlineContext _contexto;

            public manejador(SeriesOnlineContext contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(ejecuta request, CancellationToken cancellationToken)
            {
                var serie = new UsuarioSerie{
                    UsuarioId = request.usuarioid!,
                    SerieId = request.serieid!
                };

                _contexto.UsuarioSerie!.Add(serie);

                var resultado = await _contexto.SaveChangesAsync();
                if(resultado > 0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo registrar");
            }
        }
    }
}