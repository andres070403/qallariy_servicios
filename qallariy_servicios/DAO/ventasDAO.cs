using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qallariy_servicios.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace qallariy_servicios.DAO
{
    public class ventasDAO
    {
        public IEnumerable<Venta> Listado()
        {
            List<Venta> auxiliar = new List<Venta>();
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                SqlCommand cmd = new SqlCommand("usp_listar_venta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    auxiliar.Add(new Venta()
                    {
                        idVenta = dr.GetString(0),
                        vendedor = dr.GetInt32(1),
                        membresia = dr.GetInt32(2),
                        metodoPago = dr.GetInt32(3),
                        fechaCreacion = dr.GetDateTime(4),
                        fechaModificacion = dr.GetDateTime(5),
                        fechaExpiracion = dr.GetDateTime(6)
                    });
                }
            }
            return auxiliar;
        }

        public string Agregar(Venta v)

        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_insertar_venta", cn);
                    cmd.Parameters.AddWithValue("@idVen", v.vendedor);
                    cmd.Parameters.AddWithValue("@idMem", v.membresia);
                    cmd.Parameters.AddWithValue("@idMetPag", v.metodoPago);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    int rs = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha insertado {rs} ventas";
                }
                catch (Exception e)
                {
                    mensaje = "No se pudo registrar la venta : " + e.Message;
                }
            }
            return mensaje;
        }
        //public string Actualizar(Producto p)

        //{
        //    string mensaje = "";
        //    using (SqlConnection cn = new conexionDAO().getcn)
        //    {
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("usp_actualizar_producto", cn);
        //            cmd.Parameters.AddWithValue("@cod", p.idProducto);
        //            cmd.Parameters.AddWithValue("@desc", p.descripcion);
        //            cmd.Parameters.AddWithValue("@pre", p.precio);
        //            cmd.Parameters.AddWithValue("@stock", p.stock);
        //            cmd.Parameters.AddWithValue("@idest", p.idestado);
        //            cmd.Parameters.AddWithValue("@img1", p.imagen1);
        //            cmd.Parameters.AddWithValue("@img2", p.imagen2);
        //            cmd.Parameters.AddWithValue("@img3", p.imagen3);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cn.Open();
        //            int rs = cmd.ExecuteNonQuery();
        //            mensaje = $"Se ha actualizado el producto {p.idProducto}";
        //        }
        //        catch (Exception e)
        //        {
        //            mensaje = "No se pudo actualizar el producto: " + e.Message;
        //        }
        //    }
        //    return mensaje;
        //}

        //public IEnumerable<Producto> Listadoprodxid(int id)
        //{
        //    List<Producto> auxiliar = new List<Producto>();
        //    using (SqlConnection cn = new conexionDAO().getcn)
        //    {
        //        SqlCommand cmd = new SqlCommand("usp_listar_producto_id", cn);
        //        cmd.Parameters.AddWithValue("@idProd", id);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            auxiliar.Add(new Producto()
        //            {
        //                idProducto = dr.GetString(0),
        //                idnegocio = dr.GetString(1),
        //                descripcion = dr.GetString(2),
        //                precio = dr.GetDecimal(3),
        //                stock = dr.GetInt32(4),
        //                visitas = dr.GetInt32(5),
        //                meInteresa = dr.GetInt32(6),
        //                imagen1 = dr.GetString(7),
        //                imagen2 = dr.GetString(8),
        //                imagen3 = dr.GetString(9),
        //                idestado = dr.GetInt32(10),
        //                estado = dr.GetString(11)
        //            });
        //        }
        //    }
        //    return auxiliar;
        //}
    }
}
