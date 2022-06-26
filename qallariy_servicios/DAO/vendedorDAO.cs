using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qallariy_servicios.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace qallariy_servicios.DAO
{
    public class vendedorDAO
    {
        Utils u = new Utils();
        public IEnumerable<Vendedor> Listado()
        {
            List<Vendedor> auxiliar = new List<Vendedor>();
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                SqlCommand cmd = new SqlCommand("usp_listar_vendedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    auxiliar.Add(new Vendedor()
                    {
                        idVendedor = dr.GetInt32(0),
                        nombres = dr.GetString(1),
                        apellidos = dr.GetString(2),
                        correo = dr.GetString(3),
                        password = dr.GetString(4),
                        idTipDoc = dr.GetInt32(5),
                        descTipDoc = dr.GetString(6),
                        numeroDocumento = dr.GetInt32(7),
                        fechaNacimiento = u.parseDateTimeSafe(dr,8),
                        telefono = dr.GetString(9)
                    });
                }
            }
            return auxiliar;
        }
        public string Agregar(Vendedor v)

        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_insertar_vendedor", cn);
                    cmd.Parameters.AddWithValue("@nom", v.nombres);
                    cmd.Parameters.AddWithValue("@ape", v.apellidos);
                    cmd.Parameters.AddWithValue("@correo", v.correo);
                    cmd.Parameters.AddWithValue("@pass", v.password);
                    cmd.Parameters.AddWithValue("@iddoc", v.idTipDoc);
                    cmd.Parameters.AddWithValue("@numdoc", v.numeroDocumento);
                    cmd.Parameters.AddWithValue("@fecnac", v.fechaNacimiento);
                    cmd.Parameters.AddWithValue("@telefono", v.telefono);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    int rs = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha insertado {rs} vendedor";
                }
                catch (Exception e)
                {
                    mensaje = "No se pudo registrar el vendedor: " + e.Message;
                }
            }
            return mensaje;
        }
        public string Actualizar(Vendedor v)

        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_actualizar_vendedor", cn);
                    cmd.Parameters.AddWithValue("@cod", v.idVendedor);
                    cmd.Parameters.AddWithValue("@nom", v.nombres);
                    cmd.Parameters.AddWithValue("@ape", v.apellidos);
                    cmd.Parameters.AddWithValue("@correo", v.correo);
                    cmd.Parameters.AddWithValue("@fecnac", v.fechaNacimiento);
                    cmd.Parameters.AddWithValue("@telefono", v.telefono);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    int rs = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha actualizado el vendedor {v.idVendedor}";
                }
                catch (Exception e)
                {
                    mensaje = "No se pudo actualizar el vendedor: " + e.Message;
                }
            }
            return mensaje;
        }
    }
}
