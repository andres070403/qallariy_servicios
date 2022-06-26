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
        varBinaryUtils bu = new varBinaryUtils();
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
                        //imagen = dr.GetByte(5),

                        //reg.Comentario = (dr.IsDBNull(5) ? "" : dr.GetString(5));
                        //imagen = dr.IsDBNull(5) ? "" : (byte[])dr[5],
                        imagen = bu.verificarVarBinary(dr,5),
                        facebook = dr.GetString(6),
                        instagram = dr.GetString(7),
                        tiktok = dr.GetString(8),
                        correo = dr.GetString(9),
                        whatsapp = dr.GetString(10),
                        website = dr.GetString(11),
                        categoria = dr.GetString(12)
                    }) ;
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
        public IEnumerable<NegocioListado> ListadoNegocioxid(string id)
        {
            List<NegocioListado> auxiliar = new List<NegocioListado>();
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                SqlCommand cmd = new SqlCommand("usp_listar_negocio_id", cn);
                cmd.Parameters.AddWithValue("@idNeg", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    auxiliar.Add(new NegocioListado()
                    {

                        idNegocio = dr.GetString(0),
                        nombreNegocio = dr.GetString(1),
                        descripcionNegocio = dr.GetString(2),
                        direccion = dr.GetString(3),
                        telefono = dr.GetString(4),
                        imagen = bu.verificarVarBinary(dr, 5),
                        facebook = dr.IsDBNull(6) ? "" : dr.GetString(6),
                        instagram = dr.IsDBNull(7) ? "" : dr.GetString(7),
                        tiktok = dr.IsDBNull(8) ? "" : dr.GetString(8),
                        correo = dr.IsDBNull(9) ? "" : dr.GetString(9),
                        whatsapp = dr.IsDBNull(10) ? "" : dr.GetString(10),
                        website = dr.IsDBNull(11) ? "" : dr.GetString(11),
                        nombrevendedor = dr.GetString(12),
                        apellidovendedor = dr.GetString(13),
                        descripcionvendedor = dr.GetString(14),
                        numerodocvendedor = dr.GetInt32(15),
                        categoria = dr.GetString(16),
                        descdistrito = dr.GetString(17),
                        descprov = dr.GetString(18),
                        iddepart = dr.GetInt32(19),
                        descdepart = dr.GetString(20),
                    });
                }
            }
            return auxiliar;
        }
    }
}
