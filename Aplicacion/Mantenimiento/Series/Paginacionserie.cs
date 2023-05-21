using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistencia.DapperConexion.Paginacion;

namespace Aplicacion.Mantenimiento.Series
{
    public class Paginacionserie
    {
        public class ejecuta : IRequest<PaginacionModel>{
            
            public int NumeroPagina{get;set;}

            public int CantidadElementos{get;set;}
        }

        public class manejador : IRequestHandler<ejecuta, PaginacionModel>
        {
            private readonly IPaginacion _paginacion;
                public manejador(IPaginacion paginacion)
                {
                    _paginacion = paginacion;
                }
            public async Task<PaginacionModel> Handle(ejecuta request, CancellationToken cancellationToken)
            {
                var storeprocedure = "usp_obtener_paginacion_serie";
                    //este ordenamiento es el nombre de uno de los registros en la tabla
                    var ordenamiento = "NULL";//este es uno de los elementos que existen en la tabla en mi caso lo ordenare por nombre
                    var parametros = new Dictionary<string , object>();
                    return await _paginacion.DevolverPaginacion(storeprocedure, request.NumeroPagina, request.CantidadElementos , parametros,ordenamiento); 

            }
        }


    }
}