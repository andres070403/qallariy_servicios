using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qallariy_servicios.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace qallariy_servicios.DAO
{
    public class distritoDAO
    {
        public IEnumerable<Distrito> listado()

        {
            List<Distrito> auxiliar = new List<Distrito>();
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                SqlCommand cmd = new SqlCommand("usp_listar_distrito", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    auxiliar.Add(new Distrito()
                    {
                        idDistrito = dr.GetInt32(0),
                        idDepartamento = dr.GetInt32(1),
                        idProvincia = dr.GetInt32(2),
                        descripcion = dr.GetString(3)
                    });
                }
            }
            return auxiliar;
        }
        public IEnumerable<Distrito> buscarDistritoxProvincia(int id)

        {
            List<Distrito> auxiliar = new List<Distrito>();
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                SqlCommand cmd = new SqlCommand("usp_buscar_distrito_provincia", cn);
                cmd.Parameters.AddWithValue("@idProv", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    auxiliar.Add(new Distrito()
                    {
                        idDistrito = dr.GetInt32(0),
                        idDepartamento = dr.GetInt32(1),
                        idProvincia = dr.GetInt32(2),
                        descripcion = dr.GetString(3)
                    });
                }
            }
            return auxiliar;
        }
    }
}
