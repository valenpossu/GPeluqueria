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
    public class CD_ServiciosHechos
    {
        public int Registrar(ServiciosHechos oServiciosHechos, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarServicioHecho", oconexion);
                    cmd.Parameters.AddWithValue("IdServicio", oServiciosHechos.oServicios.IdServicio);
                    cmd.Parameters.AddWithValue("CantidadVendida", oServiciosHechos.CantidadVendida);
                    cmd.Parameters.AddWithValue("Descuento", oServiciosHechos.Descuento);
                    cmd.Parameters.AddWithValue("PrecioVenta", oServiciosHechos.PrecioVenta);
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

        public int UpdateInfoServicios(ServiciosHechos oServiciosHechos, out string Mensaje)
        {
            int resultado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateInfoServicios", oconexion);
                    cmd.Parameters.AddWithValue("IdServicioHecho", oServiciosHechos.IdServiciosHechos);
                    cmd.Parameters.AddWithValue("Estado", oServiciosHechos.Estado);
                    cmd.Parameters.AddWithValue("Metodo", oServiciosHechos.Metodo);
                    cmd.Parameters.AddWithValue("NoTarjeta", oServiciosHechos.NoTarjeta);
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
    }
}
