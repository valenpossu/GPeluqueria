using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Inventario
    {
        public List<Inventario> Listar()
        {
            List<Inventario> lista = new List<Inventario>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_Inventario", oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader()) //poder leer todos los resultados de la ejecucion del query
                    {
                        while (dr.Read()) //mientras esta leyendo agrega los datos al objeto lista
                        {
                            lista.Add(
                                new Inventario
                                {
                                    oProducto = new Producto() { IdProducto = Convert.ToInt32(dr["IdProducto"]), Nombre = dr["Nombre"].ToString(), Stock = Convert.ToInt32(dr["Stock"])  },
                                    StockVigente = Convert.ToInt32(dr["StockVigente"]),
                                    Entradas = Convert.ToInt32(dr["Entradas"]),
                                    Salidas = Convert.ToInt32(dr["Salidas"])
                                });

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                lista = new List<Inventario>();
            }
            return lista;
        }

        public (int,int) RegistrarEntrada(Entradas oEntradas, out string Mensaje)
        {
            int resultado = 0;
            int IdTransaccion = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarEntrada", oconexion);
                    cmd.Parameters.AddWithValue("IdProducto", oEntradas.IdProducto);
                    cmd.Parameters.AddWithValue("Entradas", oEntradas.OpInventario_Cantidad);
                    cmd.Parameters.AddWithValue("IdUsuario", oEntradas.IdUsuario);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("IdTransaccion", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    IdTransaccion = Convert.ToInt32(cmd.Parameters["IdTransaccion"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = 0;
                IdTransaccion = 0;
                Mensaje = ex.Message;
            }

            return (resultado, IdTransaccion);
        }

        public (int, int) RegistrarSalida(Salidas oSalidas, out string Mensaje)
        {
            int resultado = 0;
            int IdTransaccion = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarSalida", oconexion);
                    cmd.Parameters.AddWithValue("IdProducto", oSalidas.IdProducto);
                    cmd.Parameters.AddWithValue("Salidas", oSalidas.OpInventario_Cantidad);
                    cmd.Parameters.AddWithValue("IdUsuario", oSalidas.IdUsuario);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("IdTransaccion", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    IdTransaccion = Convert.ToInt32(cmd.Parameters["IdTransaccion"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = 0;
                IdTransaccion = 0;
                Mensaje = ex.Message;
            }

            return (resultado, IdTransaccion);
        }

        public (int, int) RegistrarEntradaProducto_Existente(Entradas oEntradas, out string Mensaje)
        {
            int resultado = 0;
            int IdTransaccion = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarEntradaProducto_Existente", oconexion);
                    cmd.Parameters.AddWithValue("IdProducto", oEntradas.IdProducto);
                    cmd.Parameters.AddWithValue("Entradas", oEntradas.OpInventario_Cantidad);
                    cmd.Parameters.AddWithValue("Cantidad", oEntradas.Cantidad);
                    cmd.Parameters.AddWithValue("IdUsuario", oEntradas.IdUsuario);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("IdTransaccion", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    IdTransaccion = Convert.ToInt32(cmd.Parameters["IdTransaccion"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = 0;
                IdTransaccion = 0;
                Mensaje = ex.Message;
            }

            return (resultado, IdTransaccion);
        }

    }
}
