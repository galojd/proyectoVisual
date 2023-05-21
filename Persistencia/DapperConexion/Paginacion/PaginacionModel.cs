using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia.DapperConexion.Paginacion
{
    public class PaginacionModel
    {
        //crea un arreglo de tipo IDictionary para que se mapee automaticamente la data 
        public List<IDictionary<string,object>> ListaRecords {get;set;}
        public int TotalRecords {get;set;}
        public int NumeroPaginas{get;set;}
    }
}