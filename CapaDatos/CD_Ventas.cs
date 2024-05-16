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
    public class CD_Ventas
    {
        public int Registrar(Ventas oVentas, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarVenta", oconexion);
                    cmd.Parameters.AddWithValue("IdProducto", oVentas.oProducto.IdProducto);
                    cmd.Parameters.AddWithValue("CantidadVendida", oVentas.CantidadVendida);
                    cmd.Parameters.AddWithValue("Descuento", oVentas.Descuento);
                    cmd.Parameters.AddWithValue("PrecioVenta", oVentas.PrecioVenta);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idautogenerado = 0;
                Mensaje = ex.Message;
            }

            return idautogenerado;
        }

        public int UpdateInfoVenta(Ventas oVentas, out string Mensaje)
        {
            int resultado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateInfoVenta", oconexion);
                    cmd.Parameters.AddWithValue("IdVenta", oVentas.IdVenta);
                    cmd.Parameters.AddWithValue("Estado", oVentas.Estado);
                    cmd.Parameters.AddWithValue("Metodo", oVentas.Metodo);
                    cmd.Parameters.AddWithValue("NoTarjeta", oVentas.NoTarjeta);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = 0;
                Mensaje = ex.Message;
            }

            return resultado;
        }

        public List<Ventas> Listar()
        {
            List<Ventas> lista = new List<Ventas>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("ListarVentaTemp", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader()) //poder leer todos los resultados de la ejecucion del query
                    {
                        while (dr.Read()) //mientras esta leyendo agrega los datos al objeto lista
                        {
                            lista.Add(
                                new Ventas
                                {
                                    IdVenta = Convert.ToInt32(dr["IdVenta"]),
                                    oProducto = new Producto() { Nombre = dr["Nombre"].ToString(), Descripcion = dr["Descripcion"].ToString(), Costo = Convert.ToDecimal(dr["Costo"]) },
                                    CantidadVendida = Convert.ToInt32(dr["CantidadVendida"]),
                                    PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"])
                                });

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                lista = new List<Ventas>();
            }
            return lista;
        }

        public int ObtenerMaximoId()
        {
            int id = 0;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SELECT MAX(IdVenta) FROM Ventas", oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    id = (int)cmd.ExecuteScalar();

                    id++;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return id;
        }
    }
}
