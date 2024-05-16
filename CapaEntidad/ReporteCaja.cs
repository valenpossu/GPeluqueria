using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ReporteCaja
    {
        public decimal SaldoCaja { get; set; }
        public decimal SaldoVentas { get; set; }
        public decimal SaldoServicio { get; set; }
        public decimal TotalVentasEfectivo { get; set; }
        public decimal TotalVentasTarjeta { get; set; }
        public decimal TotalServiciosEfectivo { get; set; }
        public decimal TotalServiciosTarjeta { get; set; }
        public decimal TotalGeneral { get; set; }
        public decimal TotalEnCaja { get; set; }


    }
}
