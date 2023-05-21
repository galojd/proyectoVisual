using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia.DapperConexion
{
    public interface IFactoryConeccion
    {
        void closeconection();
        //objeto de coneccion envuelto con data
        IDbConnection GetConection();
    }
}