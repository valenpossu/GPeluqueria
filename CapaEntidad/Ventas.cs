using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Ventas
    {
        public int IdVenta { get; set; }
        public Producto oProducto { get; set; }
        public int CantidadVendida { get; set; }
        public int Descuento { get; set; }
        public int Estado { get; set; }
        public string Metodo { get; set; }
        public decimal PrecioVenta { get; set; }
        public string NoTarjeta { get; set; }
    }
}
