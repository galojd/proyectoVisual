using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace Persistencia.DapperConexion.Paginacion
{
    public class PaginacionRepositorio : IPaginacion
    {
        private readonly IFactoryConeccion _factoryconection;
        //inyecto el factoryconecion para poder realizar operaciones con procedimientos almacenados
        public PaginacionRepositorio(IFactoryConeccion factoryconection)
        {
            _factoryconection = factoryconection;
        }

        public async Task<PaginacionModel> DevolverPaginacion(string storeProcedure, int numeroPagina, int cantidadElementos, IDictionary<string, object> parametrosfiltro, string ordenamientoColumna)
        {
            PaginacionModel paginacionmodel = new PaginacionModel();
            List<IDictionary<string, object>>? listareporte = null;
            int totalrecords = 0;
            int totalpaginas = 0;
            try{
                var conection = _factoryconection.GetConection();
                DynamicParameters parametros = new DynamicParameters();

                //con esto inserto los filtros que le hga al procedimineot almacenado
                foreach(var param in parametrosfiltro){
                    parametros.Add("@" + param.Key, param.Value);
                }

                parametros.Add("@NumeroPagina", numeroPagina);
                parametros.Add("@CantidadElementos", cantidadElementos);
                parametros.Add("@Ordenamiento", ordenamientoColumna);

                parametros.Add("@TotalRecords", totalrecords, DbType.Int32, ParameterDirection.Output);
                parametros.Add("@TotalPaginas", totalpaginas, DbType.Int32, ParameterDirection.Output);
                //nombre de procedimiento almacenado, parametros , y el tipo de transaccion
                var result = await conection.QueryAsync(storeProcedure, parametros, commandType: CommandType.StoredProcedure);
                listareporte = result.Select(x => (IDictionary<string, object>)x ).ToList();
                paginacionmodel.ListaRecords = listareporte;
                paginacionmodel.NumeroPaginas = parametros.Get<int>("@TotalPaginas");
                paginacionmodel.TotalRecords = parametros.Get<int>("@TotalRecords");
            }catch(Exception e){
                throw new Exception("No se pudo ejecutar el procedimiento almacenado", e);
            }finally{
                _factoryconection.closeconection();
            }
            return paginacionmodel;
        }
    }
}