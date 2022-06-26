using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qallariy_servicios.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace qallariy_servicios.DAO
{
    public class provinciaDAO
    {
        public IEnumerable<Provincia> listado()

        {
            List<Provincia> auxiliar = new List<Provincia>();
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                SqlCommand cmd = new SqlCommand("usp_listar_departamento", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    auxiliar.Add(new Provincia()
                    {
                        idProvincia = dr.GetInt32(0),
                        idDepartamento = dr.GetInt32(1),
                        descripcion = dr.GetString(1)
                    });
                }
            }
            return auxiliar;
        }
        public IEnumerable<Provincia> buscarPorDepartamento(int id)

        {
            List<Provincia> auxiliar = new List<Provincia>();
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                SqlCommand cmd = new SqlCommand("usp_buscar_provincia_departamento", cn);
                cmd.Parameters.AddWithValue("@idDep", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    auxiliar.Add(new Provincia()
                    {
                        idProvincia = dr.GetInt32(0),
                        idDepartamento = dr.GetInt32(1),
                        descripcion = dr.GetString(2)
                    });
                }
            }
            return auxiliar;
        }
    }
}
