using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Mantenimiento.Series
{
    public class NuevoSeries
    {
         public class ejecuta : IRequest
        {
            public string? Nombre { get; set; }

            public string? descripcion{get;set;}

            public string? Imagen { get; set; }

        }

        public class EjecutaValidacion : AbstractValidator<ejecuta>{
            public EjecutaValidacion(){
                RuleFor(x => x.Nombre).NotEmpty();
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
                Guid _Serieid = Guid.NewGuid();
                var serie = new Serie{
                    SerieId = _Serieid,
                    Nombre = request.Nombre,
                    Imagen = request.Imagen,
                    Descripcion = request.descripcion,
                    Fechacreacion = DateTime.UtcNow   
                };

                _contexto.Serie!.Add(serie);

                var resultado = await _contexto.SaveChangesAsync();
                if(resultado > 0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo registrar la nueva serie");


            }
        }

    }
}