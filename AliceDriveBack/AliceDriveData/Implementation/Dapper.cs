 using AliceDriveData.Interfaces;
using AliceDriveEntity;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceDriveData.Implementation
{
    public class Dapper : IDapper
    {
        public async Task<dynamic> Consultas<T>(string cadenaConexion, string procedimientoAlmacenado, dynamic parametros = null) where T : class
        {
            try
            {                
                using (IDbConnection connection = new SqlConnection(cadenaConexion))
                {
                    return await connection.QueryAsync<T>(procedimientoAlmacenado, param: (object)parametros, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public async Task<T> Insert<T>(string cadenaConexion, string procedimientoAlmacenado, dynamic parametros = null) where T : class
        {
            try
            {                
                using (IDbConnection connection = new SqlConnection(cadenaConexion))
                {
                    var temp = await connection.QueryAsync<T>(procedimientoAlmacenado, param: (object)parametros, commandType: CommandType.StoredProcedure);
                    return await Task.Run(() => Enumerable.FirstOrDefault<T>(temp));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
