using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ReporteFinalCaja
    {
        public int IdCaja { get; set; }
        public decimal SaldoApertura { get; set; }
        public decimal EfectivoVentas { get; set; }
        public decimal EfectivoServicios { get; set; }
        public decimal TarjetaVentas { get; set; }
        public decimal TarjetaServicios { get; set; }
        public string UsuarioA { get; set; }
        public string UsuarioC { get; set; }
        public string EstadoCaja { get; set; }
        public string Inconsistencia { get; set; }
        public decimal SaldoInc { get; set; }
        public DateTime Fecha { get; set; }
    }
}
