using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qallariy_servicios.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace qallariy_servicios.DAO
{
    public class estadoDAO
    {
        public IEnumerable<Estado> listado()

        {
            List<Estado> auxiliar = new List<Estado>();
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                SqlCommand cmd = new SqlCommand("usp_listar_estado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    auxiliar.Add(new Estado()
                    {
                        idEstado = dr.GetInt32(0),
                        descripcion = dr.GetString(1)
                    });
                }
            }
            return auxiliar;
        }
    }
}
