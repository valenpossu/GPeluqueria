using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Entradas
    {
        public int IdTransaccion { get; set; }
        public string IdProducto { get; set; }
        public string IdUsuario { get; set; }
        public int OpInventario_Cantidad { get; set; }
        public int Cantidad { get; set; }
    }
}
