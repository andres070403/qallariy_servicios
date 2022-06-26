using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qallariy_servicios.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace qallariy_servicios.DAO
{
    public class metodoPagoDAO
    {
                public IEnumerable<MetodoPago> listado()

        {
            Vendedor v = new Vendedor();
            List<MetodoPago> auxiliar = new List<MetodoPago>();
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                SqlCommand cmd = new SqlCommand("usp_listar_metodo_pago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    auxiliar.Add(new MetodoPago()
                    {
                        idMetPag = dr.GetInt32(0),
                        titular = dr.GetString(1),
                        tipo = dr.GetString(2),
                        numero = dr.GetString(3),
                        codigo = dr.GetString(5),
                        fechaVencimiento = dr.GetDateTime(6),
                        vendedor = new Vendedor() { idVendedor = dr.GetInt32(8) }
                    });
                }
            }
            return auxiliar;
        }
        public string Agregar(MetodoPago mp)
        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_insertar_metodo_pago", cn);
                    cmd.Parameters.AddWithValue("@titu", mp.titular);
                    cmd.Parameters.AddWithValue("@tip", mp.tipo);
                    cmd.Parameters.AddWithValue("@num", mp.numero);
                    cmd.Parameters.AddWithValue("@fecVen", mp.fechaVencimiento);
                    cmd.Parameters.AddWithValue("@cod", mp.codigo);
                    cmd.Parameters.AddWithValue("@idVen", mp.vendedor.idVendedor);
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
        public IEnumerable<MetodoPago> ListarPorVendedor(int idVen)

        {
            List<MetodoPago> auxiliar = new List<MetodoPago>();
            using (SqlConnection cn = new conexionDAO().getcn)
            {
                SqlCommand cmd = new SqlCommand("usp_listar_metodoPago_vendedor", cn);
                cmd.Parameters.AddWithValue("@idVen", idVen);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    auxiliar.Add(new MetodoPago()
                    {
                        idMetPag = dr.GetInt32(0),
                        titular = dr.GetString(1),
                        tipo = dr.GetString(2),
                        numero = dr.GetString(3),
                        fechaVencimiento = dr.GetDateTime(5),
                        codigo = dr.GetString(4),
                    });
                }
            }
            return auxiliar;
        }
    }
}
