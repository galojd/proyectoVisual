using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Persistencia.DapperConexion
{
    public class FactoryConeccion : IFactoryConeccion
    {
        private IDbConnection _connection;
        private readonly IOptions<ConexionConfiguracion> _config;
        public FactoryConeccion(IOptions<ConexionConfiguracion> config)
        {
            _config = config;
        }

        //se crea porque no puedo dejar una conexion abierta cada vez que hago una peticion
        public void closeconection()
        {
            if(_connection != null && _connection.State == ConnectionState.Open){
                _connection.Close();
            }
        }

        public IDbConnection GetConection()
        {
            //evalua que la cadena de conexion existe, si no existe se crea una
            if(_connection == null){
                _connection = new SqlConnection(_config.Value.DefaultConnection);
            }
            //evalua que la cadena de conexion este abierta
            if(_connection.State != ConnectionState.Open){
                _connection.Open();
            }
            return _connection;
        }
    }
}