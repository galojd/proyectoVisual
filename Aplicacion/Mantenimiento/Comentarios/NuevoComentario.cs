using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Mantenimiento.Comentarios
{
    public class NuevoComentario
    {
        public class ejecuta : IRequest
        {
            public string? ComentarioTexto { get; set; }
            public string? UsuarioId { get; set; }
            public Guid? CapituloId { get; set; }
            public Guid? SerieId { get; set; }
            public string? userName{get;set;}

        }

        public class EjecutaValidacion : AbstractValidator<ejecuta>{
            public EjecutaValidacion(){
                RuleFor(x => x.ComentarioTexto).NotEmpty();
                RuleFor(x => x.UsuarioId).NotEmpty();
                RuleFor(x => x.SerieId).NotEmpty();
            }

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

                var usuarioExistente = await _contexto.Usuario!.FirstOrDefaultAsync(u => u.UserName == request.userName);

                if (usuarioExistente == null || usuarioExistente.Id != request.UsuarioId)
                {
                    throw new Exception("El nombre de usuario no está relacionado con un id de usuario existente");
                }

                Guid _Comentarioid = Guid.NewGuid();
                var comentario = new Comentario{
                    ComentarioId = _Comentarioid,
                    ComentarioTexto = request.ComentarioTexto,
                    UsuarioId = request.UsuarioId,
                    userName = request.userName,
                    CapituloId = request.CapituloId,
                    SerieId = request.SerieId,
                    Fechacreacion = DateTime.UtcNow
                };
                _contexto.Comentario!.Add(comentario);

                var resultado = await _contexto.SaveChangesAsync();
                if(resultado > 0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo registrar su comentario");
                
            }
        }
    }
}