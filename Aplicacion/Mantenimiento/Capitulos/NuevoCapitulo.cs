using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using MediatR;
using Persistencia;

namespace Aplicacion.Mantenimiento.Capitulos
{
    public class NuevoCapitulo
    {
        public class ejecuta : IRequest
        {
            public int? NumeroCapitulo { get; set; }
            public string? NombreCapitulo { get; set; }
            public string? CapituloUrl { get; set; }
            public string? imagenurl { get; set; }
            public Guid? SerieId { get; set; }
            public int? Temporada { get; set; }

        }

        public class Manejador : IRequestHandler<ejecuta>
        {
            private readonly SeriesOnlineContext _contexto;
            public Manejador(SeriesOnlineContext contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(ejecuta request, CancellationToken cancellationToken)
            {
                Guid _Capitiloid = Guid.NewGuid();
                var capitulo = new Capitulo{
                    CapituloId = _Capitiloid,
                    NumeroCapitulo = request.NumeroCapitulo,
                    NombreCapitulo = request.NombreCapitulo,
                    CapituloUrl = request.CapituloUrl,
                    imagenurl = request.imagenurl,
                    SerieId = request.SerieId,
                    Temporada = request.Temporada,
                    Fechacreacion = DateTime.UtcNow
                };
                _contexto.Capitulo!.Add(capitulo);

                var resultado = await _contexto.SaveChangesAsync();
                if(resultado > 0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo registrar el nuevo capitulo");
                
            }
        }

    }
}