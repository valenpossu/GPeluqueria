﻿using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Reportes
    {
        public Dashboard VerDashboard()
        {
            Dashboard objeto = new Dashboard();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("Sp_ReporteDashboard", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader()) //poder leer todos los resultados de la ejecucion del query
                    {
                        while (dr.Read()) //mientras esta leyendo agrega los datos al objeto lista
                        {
                            objeto = new Dashboard()
                            {
                                TotalEmpleados = Convert.ToInt32(dr["TotalEmpleados"]),
                                TotalServiciosRealizados = Convert.ToInt32(dr["TotalServiciosRealizados"]),
                                TotalVentas = Convert.ToInt32(dr["TotalVentas"]),
                                TotalProductos = Convert.ToInt32(dr["TotalProductos"])
                            };


                        }
                    }

                }
            }
            catch (Exception ex)
            {
                objeto = new Dashboard();
            }
            return objeto;
        }

        public ReporteCaja VerReporteCaja()
        {
            ReporteCaja objeto = new ReporteCaja();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("Sp_ReporteCaja", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader()) //poder leer todos los resultados de la ejecucion del query
                    {
                        while (dr.Read()) //mientras esta leyendo agrega los datos al objeto lista
                        {
                            objeto = new ReporteCaja()
                            {
                                SaldoCaja = Convert.ToDecimal(dr["SaldoCaja"]),
                                SaldoVentas = Convert.ToDecimal(dr["SaldoVentas"]),
                                SaldoServicio = Convert.ToDecimal(dr["SaldoServicio"]),
                                TotalVentasEfectivo = Convert.ToDecimal(dr["TotalVentasEfectivo"]),
                                TotalVentasTarjeta = Convert.ToDecimal(dr["TotalVentasTarjeta"]),
                                TotalServiciosEfectivo = Convert.ToDecimal(dr["TotalServiciosEfectivo"]),
                                TotalServiciosTarjeta = Convert.ToDecimal(dr["TotalServiciosTarjeta"]),
                                TotalGeneral = Convert.ToDecimal(dr["TotalGeneral"]),
                                TotalEnCaja = Convert.ToDecimal(dr["TotalEnCaja"]),
                            };

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                objeto = new ReporteCaja();
            }
            return objeto;
        }

        public ReporteFinalCaja VerReporteCajaFinal()
        {
            ReporteFinalCaja objeto = new ReporteFinalCaja();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("ReporteFinalCaja", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader()) //poder leer todos los resultados de la ejecucion del query
                    {
                        while (dr.Read()) //mientras esta leyendo agrega los datos al objeto lista
                        {
                            objeto = new ReporteFinalCaja()
                            {
                                IdCaja = Convert.ToInt32(dr["IdCaja"]),
                                SaldoApertura = Convert.ToDecimal(dr["SaldoApertura"]),
                                EfectivoVentas = Convert.ToDecimal(dr["EfectivoVentas"]),
                                EfectivoServicios = Convert.ToDecimal(dr["EfectivoServicios"]),
                                TarjetaVentas = Convert.ToDecimal(dr["TarjetaVentas"]),
                                TarjetaServicios = Convert.ToDecimal(dr["TarjetaServicios"]),
                                UsuarioA = dr["UsuarioA"].ToString(),
                                UsuarioC = dr["UsuarioC"].ToString(),
                                EstadoCaja = dr["EstadoCaja"].ToString(),
                                Inconsistencia = dr["Inconsistencia"].ToString(),
                                SaldoInc = Convert.ToDecimal(dr["SaldoInc"]),
                                Fecha = Convert.ToDateTime( dr["Fecha"])
                            };

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objeto = new ReporteFinalCaja();
            }

            return objeto;
        }

        public List<Reporte> Ventas(string FechaInicio, string FechaFin)
        {
            List<Reporte> lista = new List<Reporte>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_ReporteVentas", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("FechaInicio", FechaInicio);
                    cmd.Parameters.AddWithValue("FechaFin", FechaFin);
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader()) //poder leer todos los resultados de la ejecucion del query
                    {
                        while (dr.Read()) //mientras esta leyendo agrega los datos al objeto lista
                        {
                            lista.Add(
                                new Reporte
                                {
                                    FechaVenta = dr["FechaVenta"].ToString(),
                                    Producto = dr["Producto"].ToString(),
                                    CantidadVendida = Convert.ToInt32(dr["CantidadVendida"]),
                                    PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"], new CultureInfo("es-CO")),
                                    Estado = dr["Estado"].ToString(),
                                    Descuento = Convert.ToInt32(dr["Descuento"], new CultureInfo("es-CO")),
                                    
                                });

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                lista = new List<Reporte>();
            }

            return lista;
        }


    }
}