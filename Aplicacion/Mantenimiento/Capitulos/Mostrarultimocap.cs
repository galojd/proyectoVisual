using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistencia.DapperConexion.Paginacion;

namespace Aplicacion.Mantenimiento.Capitulos
{
    public class Mostrarultimocap
    {
        public class ejecuta : IRequest<PaginacionModel>{
                     
            public int NumeroPagina{get;set;}
            public int CantidadElementos{get;set;}

            public class manejador : IRequestHandler<ejecuta, PaginacionModel>
            {
                private readonly IPaginacion _paginacion;
                public manejador(IPaginacion paginacion)
                {
                    _paginacion = paginacion;
                }

                public async Task<PaginacionModel> Handle(ejecuta request, CancellationToken cancellationToken)
                {
                    var storeprocedure = "usp_obtener_ultimos_capitulos";
                    //este ordenamiento es el nombre de uno de los registros en la tabla
                    var ordenamiento = "Fecha";
                    var parametros = new Dictionary<string , object>();
                    return await _paginacion.DevolverPaginacion(storeprocedure, request.NumeroPagina, request.CantidadElementos, parametros,ordenamiento); 

                }
            }
        }
    }
}