using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CierreCaja
    {
        public Caja oCaja { get; set; }
        public decimal EfectivoVentas { get; set; }
        public decimal EfectivoServicios { get; set; }
        public decimal TarjetaVentas { get; set; }
        public decimal TarjetaServicios { get; set; }
        public string Inc { get; set; }
        public decimal SaldoInc { get; set; }
        public Usuario oUsuario { get; set; }
    }
}
