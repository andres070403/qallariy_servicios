using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qallariy_servicios.Models;
using Microsoft.Data.SqlClient;
using System.Data;


namespace qallariy_servicios.DAO
{
    public class membresiaDAO
    {
        public IEnumerable<Membresia> listado()

        {
            List<Membresia> auxiliar = new List<Membresia>();
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                SqlCommand cmd = new SqlCommand("usp_listar_membresia", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    auxiliar.Add(new Membresia()
                    {
                        idMembresia = dr.GetInt32(0),
                        descripcion = dr.GetString(1),
                        precio = dr.GetDecimal(2),
                        duracion = dr.GetInt32(3)
                    });
                }
            }
            return auxiliar;
        }
    }
}
