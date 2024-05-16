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
    public class CD_Empleado
    {
        public List<Empleado> listar()
        {
            List<Empleado> lista = new List<Empleado>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT e.IdEmpleado,e.Nombre,e.Apellido,e.Salario,e.Correo,e.Clave,e.Reestablecer, dn.IdNegocio, dn.Nombre[NombreNegocio]");
                    sb.AppendLine("FROM Empleados e");
                    sb.AppendLine("INNER JOIN DatosNegocio dn ON E.IdNegocio = dn.IdNegocio");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader()) //poder leer todos los resultados de la ejecucion del query
                    {
                        while (dr.Read()) //mientras esta leyendo agrega los datos al objeto lista
                        {
                            lista.Add(
                                new Empleado
                                {
                                    IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Apellido = dr["Apellido"].ToString(),
                                    Salario = Convert.ToDecimal( dr["Salario"]),
                                    Correo = dr["Correo"].ToString(),
                                    Clave = dr["Clave"].ToString(),
                                    Reestablecer = Convert.ToBoolean(dr["Reestablecer"].ToString()),
                                    oDatosNegocio = new DatosNegocio() { IdNegocio = Convert.ToInt32(dr["IdNegocio"]), Nombre = dr["NombreNegocio"].ToString() }
                                });

                        }
                    }

                }
            }
            catch (Exception)
            {
                lista = new List<Empleado>();
            }
            return lista;
        }

        public int Registrar(Empleado oEmpleado, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarEmpleado", oconexion);
                    cmd.Parameters.AddWithValue("Nombre", oEmpleado.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oEmpleado.Apellido);
                    cmd.Parameters.AddWithValue("Salario", oEmpleado.Salario);
                    cmd.Parameters.AddWithValue("Correo", oEmpleado.Correo);
                    cmd.Parameters.AddWithValue("Clave", oEmpleado.Clave);
                    cmd.Parameters.AddWithValue("IdNegocio", oEmpleado.oDatosNegocio.IdNegocio);
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

        public bool Editar(Empleado oEmpleado, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarEmpleados", oconexion);
                    cmd.Parameters.AddWithValue("IdEmpleado", oEmpleado.IdEmpleado);
                    cmd.Parameters.AddWithValue("Nombre", oEmpleado.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oEmpleado.Apellido);
                    cmd.Parameters.AddWithValue("Salario", oEmpleado.Salario);
                    cmd.Parameters.AddWithValue("Correo", oEmpleado.Correo);
                    cmd.Parameters.AddWithValue("IdNegocio", oEmpleado.oDatosNegocio.IdNegocio);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }

            return resultado;
        }

    }
}
