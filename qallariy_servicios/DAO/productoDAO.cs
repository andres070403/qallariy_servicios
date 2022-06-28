using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qallariy_servicios.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace qallariy_servicios.DAO
{
    public class productoDAO
    {
        Utils vbu = new Utils();
        public IEnumerable<Producto> Listado()
        {
           string vacio = "";
            List<Producto> auxiliar = new List<Producto>();
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                SqlCommand cmd = new SqlCommand("usp_listar_producto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
          
                    while (dr.Read())
                    {
                    auxiliar.Add(new Producto()
                        {
                            idProducto = dr.GetString(0),
                            idnegocio = dr.GetString(1),
                            descripcion = dr.GetString(2),
                            precio = dr.GetDecimal(3),
                            stock = dr.GetInt32(4),
                            visitas = dr.GetInt32(5),
                            meInteresa = dr.GetInt32(6),
                            fecha_creacion = dr.GetDateTime(7),
                            fecha_modificacion = dr.GetDateTime(8),
                            idestado = dr.GetInt32(9),
                            imagen1 = vbu.verificarVarBinary(dr,10),
                            imagen2 = vbu.verificarVarBinary(dr, 11),
                            imagen3 = vbu.verificarVarBinary(dr, 12),
                        });
                    }
                
            }
            return auxiliar;
        }

        public string Agregar(Producto p)

        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_insertar_producto", cn);
                    cmd.Parameters.AddWithValue("@idneg", p.idnegocio);
                    cmd.Parameters.AddWithValue("@desc", p.descripcion);
                    cmd.Parameters.AddWithValue("@pre", p.precio);
                    cmd.Parameters.AddWithValue("@stock", p.stock);
                    cmd.Parameters.AddWithValue("@idest", p.idestado);
                    cmd.Parameters.AddWithValue("@img1", p.imagen1);
                    cmd.Parameters.AddWithValue("@img2", p.imagen2);
                    cmd.Parameters.AddWithValue("@img3", p.imagen3);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    int rs = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha insertado {rs} producto";
                }
                catch (Exception e)
                {
                    mensaje = "No se pudo registrar el producto: " + e.Message;
                }
            }
            return mensaje;
        }
        public string Actualizar(Producto p)

        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_actualizar_producto", cn);
                    cmd.Parameters.AddWithValue("@cod", p.idProducto);
                    cmd.Parameters.AddWithValue("@desc", p.descripcion);
                    cmd.Parameters.AddWithValue("@pre", p.precio);
                    cmd.Parameters.AddWithValue("@stock", p.stock);
                    cmd.Parameters.AddWithValue("@idest", p.idestado);
                    cmd.Parameters.AddWithValue("@img1", p.imagen1);
                    cmd.Parameters.AddWithValue("@img2", p.imagen2);
                    cmd.Parameters.AddWithValue("@img3", p.imagen3);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    int rs = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha actualizado el producto {p.idProducto}";
                }
                catch (Exception e)
                {
                    mensaje = "No se pudo actualizar el producto: " + e.Message;
                }
            }
            return mensaje;
        }

        public IEnumerable<Producto> Listadoprodxid(string id)
        {
            List<Producto> auxiliar = new List<Producto>();
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                SqlCommand cmd = new SqlCommand("usp_listar_producto_id", cn);
                cmd.Parameters.AddWithValue("@idProd", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    auxiliar.Add(new Producto()
                    {
                        idProducto = dr.GetString(0),
                        idnegocio = dr.GetString(1),
                        descripcion = dr.GetString(2),
                        precio = dr.GetDecimal(3),
                        stock = dr.GetInt32(4),
                        visitas = dr.GetInt32(5),
                        meInteresa = dr.GetInt32(6),
                        imagen1 = vbu.verificarVarBinary(dr, 7),
                        imagen2 = vbu.verificarVarBinary(dr, 8),
                        imagen3 = vbu.verificarVarBinary(dr, 9),
                        idestado = dr.GetInt32(10),
                        estado = dr.GetString(11)
                    });
                }
            }
            return auxiliar;
        }
        public IEnumerable<Producto> Listadoprodxidnegocio(string id)
        {
            List<Producto> auxiliar = new List<Producto>();
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                SqlCommand cmd = new SqlCommand("usp_listar_productos_negocio", cn);
                cmd.Parameters.AddWithValue("@idNeg", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    auxiliar.Add(new Producto()
                    {
                        idProducto = dr.GetString(0),
                        descripcion = dr.GetString(1),
                        precio = dr.GetDecimal(2),
                        stock = dr.GetInt32(3),
                        meInteresa = dr.GetInt32(4),
                        imagen1 = vbu.verificarVarBinary(dr, 5),
                        imagen2 = vbu.verificarVarBinary(dr, 6),
                        imagen3 = vbu.verificarVarBinary(dr, 7),
                        idestado = dr.GetInt32(8),
                        estado = dr.GetString(9)
                    });
                }
            }
            return auxiliar;
        }
    }
}
