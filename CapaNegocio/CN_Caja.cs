using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Caja
    {
        //instancia de la capa datos donde estan los metodos; asi podemos acceder a todos sus metodos
        private CD_Caja objCapaDato = new CD_Caja();

        public int ValidarCaja(out string Mensaje)
        {
            return objCapaDato.ValidarCaja(out Mensaje);
        }

        public int AbrirCaja(Caja oCaja, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (oCaja.SaldoCaja == 0)
            {
                Mensaje = "Debe Ingresar El Valor de Saldo Actual de Caja";
            }
            else if (oCaja.oUsuario.IdUsuario == 0)
            {
                Mensaje = "No Esta Relacionado El Usuario";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.AbrirCaja(oCaja, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public int InfoCaja()
        {
            return objCapaDato.InfoCaja();
        }

        public int CierreCaja(Caja oCaja, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (oCaja.IdCaja == 0)
            {
                Mensaje = "Error con Id de Caja para el Cierre";
            }
            

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.CierreCaja(oCaja, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public int SaldoCaja(CierreCaja oCCaja, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (oCCaja.oCaja.IdCaja == 0)
            {
                Mensaje = "Error con Id de Caja";
            } 
            else if(oCCaja.oUsuario.IdUsuario == 0)
            {
                Mensaje = "Error con Id de Usuario";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.SaldoCaja(oCCaja, out Mensaje);
            }
            else
            {
                return 0;
            }
        }
    }
}
