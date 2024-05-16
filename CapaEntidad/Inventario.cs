using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Inventario
    {
        public Producto oProducto { get; set; }
        public int StockVigente { get; set; }
        public int Entradas { get; set; }
        public int Salidas { get; set; }
    }
}
