using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Caja
    {
        public int IdCaja { get; set; }
        public decimal SaldoCaja { get; set; }
        public int Estado { get; set; }
        public Usuario oUsuario { get; set; }

    }
}
