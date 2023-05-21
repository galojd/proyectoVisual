using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia.DapperConexion.Paginacion
{
    public interface IPaginacion
    {
        Task<PaginacionModel> DevolverPaginacion(string storeProcedure, 
            int numeroPagina, 
            int cantidadElementos, 
            IDictionary<string, object> parametrosfiltro,
            string ordenamientoColumna);
    }
}