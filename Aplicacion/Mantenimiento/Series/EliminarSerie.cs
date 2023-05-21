using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Mantenimiento.Series
{
    public class EliminarSerie
    {
        public class ejecuta : IRequest{
            public Guid Codigoserie{get;set;}
        }

        public class manejador : IRequestHandler<ejecuta>
        {
            private readonly SeriesOnlineContext _contexto;
            public manejador(SeriesOnlineContext context)
            {
                _contexto = context;
            }
            public async Task<Unit> Handle(ejecuta request, CancellationToken cancellationToken)
            {

                //primero busco UsuarioSerie ligados a Serie
                var usuarioserieDB = _contexto.UsuarioSerie!.Where(x => x.SerieId == request.Codigoserie);
                foreach(var usuarioserie in usuarioserieDB){
                    _contexto.UsuarioSerie!.Remove(usuarioserie);
                }

                                
                //busco Comenatarios ligados a Serie
                var comentarioDB = _contexto.Comentario!.Where(x => x.SerieId == request.Codigoserie);
                foreach(var comentario in comentarioDB){
                    _contexto.Comentario!.Remove(comentario);
                }

                //busco capitulos ligados a Serie
                var capituloDB = _contexto.Capitulo!.Where(x => x.SerieId == request.Codigoserie);
                foreach(var capitulo in capituloDB){
                    _contexto.Capitulo!.Remove(capitulo);
                }

                //busco generos ligados a Serie
                var generoserieDB = _contexto.GeneroSerie!.Where(x => x.SerieId == request.Codigoserie);
                foreach(var generoserie in generoserieDB){
                    _contexto.GeneroSerie!.Remove(generoserie);
                }



                var serie = await _contexto.Serie!.FindAsync(request.Codigoserie);
                if(serie == null){
                    //throw new Exception("El instructor no existe");
                    //aqui se comunica cpn el manejadro excepcion
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "no se pudo encontrar la Serie a eliminar"});
                }
                _contexto.Remove(serie);
                
                var resultado = await _contexto.SaveChangesAsync();
                if(resultado > 0){
                    return Unit.Value;
                }
                throw new Exception("No se pudo eliminar el registro");
            }
        }
    }
}