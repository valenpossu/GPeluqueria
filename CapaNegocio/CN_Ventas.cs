using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Ventas
    {
        //instancia de la capa datos donde estan los metodos; asi podemos acceder a todos sus metodos
        private CD_Ventas objCapaDato = new CD_Ventas();

        public int Registrar(Ventas oVentas, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (oVentas.oProducto.IdProducto == 0)
            {
                Mensaje = "Ingrese Producto A Vender";
            }
            else if (oVentas.CantidadVendida == 0)
            {
                Mensaje = "La Cantidad Vendida del Producto no puede ser vacia";
            }
            else if (oVentas.PrecioVenta == 0)
            {
                Mensaje = "Verifique El Precio De La Venta, No Puede Ser Vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(oVentas, out Mensaje);
            }
            else
            {
                return 0;
            }

        }


        public int UpdateInfoVenta(Ventas oVentas, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (oVentas.IdVenta == 0)
            {
                Mensaje = "No Esta Relacionada La Venta";
            }
            else if (string.IsNullOrEmpty(oVentas.Metodo) || string.IsNullOrWhiteSpace(oVentas.Metodo))
            {
                Mensaje = "Verifique Metodo de Pago";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.UpdateInfoVenta(oVentas, out Mensaje);
            }
            else
            {
                return 0;
            }

        }

        public List<Ventas> Listar()
        {
            return objCapaDato.Listar();
        }

        public int ObtenerMaximoId()
        {
            return objCapaDato.ObtenerMaximoId();
        }
    }
}
