using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliceDriveData.Interfaces
{
    public interface IDapper
    {
        Task<dynamic> Consultas<T>(string cadenaConexion, string procedimientoAlmacenado, dynamic parametros = null) where T : class;

        Task<T> Insert<T>(string cadenaConexion, string procedimientoAlmacenado, dynamic parametros = null) where T : class;
    }
}
