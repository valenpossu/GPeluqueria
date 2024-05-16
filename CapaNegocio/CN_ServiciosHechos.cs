using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_ServiciosHechos
    {
        //instancia de la capa datos donde estan los metodos; asi podemos acceder a todos sus metodos
        private CD_ServiciosHechos objCapaDato = new CD_ServiciosHechos();

        public int Registrar(ServiciosHechos oServiciosHechos, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (oServiciosHechos.oServicios.IdServicio == 0)
            {
                Mensaje = "Ingrese Servicio A Registrar";
            }
            else if (oServiciosHechos.CantidadVendida == 0)
            {
                Mensaje = "La Cantidad del Servicio no puede ser vacia";
            }
            else if (oServiciosHechos.PrecioVenta == 0)
            {
                Mensaje = "Verifique El Precio Del Servicio, No Puede Ser Vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(oServiciosHechos, out Mensaje);
            }
            else
            {
                return 0;
            }

        }

        public int UpdateInfoServicios(ServiciosHechos oServiciosHechos, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (oServiciosHechos.IdServiciosHechos == 0)
            {
                Mensaje = "No Esta Relacionada La Venta";
            }
            else if (string.IsNullOrEmpty(oServiciosHechos.Metodo) || string.IsNullOrWhiteSpace(oServiciosHechos.Metodo))
            {
                Mensaje = "Verifique Metodo de Pago";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.UpdateInfoServicios(oServiciosHechos, out Mensaje);
            }
            else
            {
                return 0;
            }
        }
    }
}
