using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qallariy_servicios.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace qallariy_servicios.DAO
{
    public class tipoDocumentoDAO
    {
        public IEnumerable<TipoDocumento> listado()

        {
            List<TipoDocumento> auxiliar = new List<TipoDocumento>();
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                SqlCommand cmd = new SqlCommand("usp_listar_tipo_documento", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    auxiliar.Add(new TipoDocumento()
                    {
                        idTipDoc = dr.GetInt32(0),
                        descripcion = dr.GetString(1)
                    });
                }
            }
            return auxiliar;
        }
    }
}
