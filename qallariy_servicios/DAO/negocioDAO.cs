using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qallariy_servicios.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace qallariy_servicios.DAO
{
    public class negocioDAO
    {
        public IEnumerable<Negocio> Listado()
        {
            List<Negocio> auxiliar = new List<Negocio>();
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                SqlCommand cmd = new SqlCommand("usp_listar_negocio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    auxiliar.Add(new Negocio()
                    {
                        idNegocio = dr.GetString(0),
                        nombreNegocio = dr.GetString(1),
                        descripcionNegocio = dr.GetString(2),
                        direccion = dr.GetString(3),
                        telefono = dr.GetString(4),
                        imagen = dr.GetString(5),
                        facebook = dr.GetString(6),
                        instagram = dr.GetString(7),
                        tiktok = dr.GetString(8),
                        correo = dr.GetString(9),
                        whatsapp = dr.GetString(10),
                        website = dr.GetString(11),
                        categoria = dr.GetString(12),
                    });
                }
            }
            return auxiliar;
        }
        public string Agregar(Negocio n)

        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_insertar_negocio", cn);
                    cmd.Parameters.AddWithValue("@nom", n.nombreNegocio);
                    cmd.Parameters.AddWithValue("@desc", n.descripcionNegocio);
                    cmd.Parameters.AddWithValue("@idven", n.vendedor);
                    cmd.Parameters.AddWithValue("@idcat", n.categoria);
                    cmd.Parameters.AddWithValue("@iddist", n.distrito);
                    cmd.Parameters.AddWithValue("@dir", n.direccion);
                    cmd.Parameters.AddWithValue("@tel", n.telefono);
                    cmd.Parameters.AddWithValue("@img", n.imagen);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    int rs = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha insertado {rs} negocio";
                }
                catch (Exception e)
                {
                    mensaje = "No se pudo registrar el negocio: " + e.Message;
                }
            }
            return mensaje;
        }
        public string Actualizar(Negocio n)

        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_actualizar_negocio", cn);
                    cmd.Parameters.AddWithValue("@cod", n.idNegocio);
                    cmd.Parameters.AddWithValue("@nom", n.nombreNegocio);
                    cmd.Parameters.AddWithValue("@desc", n.descripcionNegocio);
                    cmd.Parameters.AddWithValue("@idcat", n.categoria);
                    cmd.Parameters.AddWithValue("@iddist", n.distrito);
                    cmd.Parameters.AddWithValue("@dir", n.direccion);
                    cmd.Parameters.AddWithValue("@tel", n.telefono);
                    cmd.Parameters.AddWithValue("@img", n.imagen);
                    cmd.Parameters.AddWithValue("@fb", n.facebook);
                    cmd.Parameters.AddWithValue("@ig", n.instagram);
                    cmd.Parameters.AddWithValue("@tk", n.tiktok);
                    cmd.Parameters.AddWithValue("@correo", n.correo);
                    cmd.Parameters.AddWithValue("@ws", n.whatsapp);
                    cmd.Parameters.AddWithValue("@website", n.website);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    int rs = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha actualizado el negocio {n.idNegocio}";
                }
                catch (Exception e)
                {
                    mensaje = "No se pudo actualizar el negocio: " + e.Message;
                }
            }
            return mensaje;
        }
        public IEnumerable<Negocio> ListadoNegocioxid(int id)
        {
            List<Negocio> auxiliar = new List<Negocio>();
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                SqlCommand cmd = new SqlCommand("usp_listar_negocio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    auxiliar.Add(new Negocio()
                    {
                        idNegocio = dr.GetString(0),
                        nombreNegocio = dr.GetString(1),
                        descripcionNegocio = dr.GetString(2),
                        direccion = dr.GetString(3),
                        telefono = dr.GetString(4),
                        imagen = dr.GetString(5),
                        facebook = dr.GetString(6),
                        instagram = dr.GetString(7),
                        tiktok = dr.GetString(8),
                        correo = dr.GetString(9),
                        whatsapp = dr.GetString(10),
                        website = dr.GetString(11),
                        categoria = dr.GetString(12),
                    });
                }
            }
            return auxiliar;
        }
    }
}
