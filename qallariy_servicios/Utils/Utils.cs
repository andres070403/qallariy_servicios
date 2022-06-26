using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qallariy_servicios.Models
{
    public class varBinaryUtils
    {
        public byte[] verificarVarBinary(SqlDataReader dr, int fila)
        {
            byte[] data = null;
            if (!dr.GetSqlBytes(fila).IsNull)
                data = (byte[])dr[fila];

            return data;
        }
    }
}
