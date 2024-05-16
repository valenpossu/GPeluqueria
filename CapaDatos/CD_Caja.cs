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
    public class CD_Caja
    {
        public int ValidarCaja(out string Mensaje)
        {
            int id = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("ValidarCaja", oconexion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    id = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                id = 0;
                Mensaje = ex.Message;
            }

            return id;
        }

        public int AbrirCaja(Caja oCaja,out string Mensaje)
        {
            int id = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("AbrirCaja", oconexion);
                    cmd.Parameters.AddWithValue("SaldoCaja", oCaja.SaldoCaja);
                    cmd.Parameters.AddWithValue("Estado", oCaja.Estado);
                    cmd.Parameters.AddWithValue("IdUsuario", oCaja.oUsuario.IdUsuario);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    id = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                id = 0;
                Mensaje = ex.Message;
            }

            return id;
        }

        public int InfoCaja()
        {
            int id = 0;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("InfoCaja", oconexion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    id = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                }
            }
            catch (Exception ex)
            {
                id = 0;
            }

            return id;
        }
        public int CierreCaja(Caja oCaja, out string Mensaje)
        {
            int id = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("OperacionCierre_Caja", oconexion);
                    cmd.Parameters.AddWithValue("IdCaja", oCaja.IdCaja);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    id = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                id = 0;
                Mensaje = ex.Message;
            }

            return id;
        }

        public int SaldoCaja(CierreCaja oCCaja, out string Mensaje)
        {
            int id = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SaldosCaja", oconexion);
                    cmd.Parameters.AddWithValue("IdCaja", oCCaja.oCaja.IdCaja);
                    cmd.Parameters.AddWithValue("EfectivoVentas", oCCaja.EfectivoVentas);
                    cmd.Parameters.AddWithValue("EfectivoServicios", oCCaja.EfectivoServicios);
                    cmd.Parameters.AddWithValue("TarjetaServicios", oCCaja.TarjetaServicios);
                    cmd.Parameters.AddWithValue("TarjetaVentas", oCCaja.TarjetaVentas);
                    cmd.Parameters.AddWithValue("Inc", oCCaja.Inc);
                    cmd.Parameters.AddWithValue("SaldoInc", oCCaja.SaldoInc);
                    cmd.Parameters.AddWithValue("Usuario", oCCaja.oUsuario.IdUsuario);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    id = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                id = 0;
                Mensaje = ex.Message;
            }

            return id;
        }
    }
}
