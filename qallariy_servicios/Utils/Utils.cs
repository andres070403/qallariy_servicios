using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qallariy_servicios.Models
{
    public class Utils
    {
        public byte[] verificarVarBinary(SqlDataReader dr, int fila)
        {
            byte[] data = null;
            if (!dr.GetSqlBytes(fila).IsNull)
                data = (byte[])dr[fila];

            return data;
        }

        public String parseDateTimeSafe(SqlDataReader dr, int fila)        
        {
            String date = "";

            if (!dr.GetSqlDateTime(fila).IsNull)
                date = dr.GetDateTime(8).ToString("dd/MM/yyyy");

            return date;
        }
    }

    
}
