using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Inventario
    {
        //instancia de la capa datos donde estan los metodos; asi podemos acceder a todos sus metodos
        private CD_Inventario objCapaDato = new CD_Inventario();
        public List<Inventario> listar()
        {
            return objCapaDato.Listar();
        }

        public int RegistrarEntrada(Entradas oEntradas, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (oEntradas.IdProducto == "0")
            {
                Mensaje = "Error Al Agregar Entrada, No esta asociado un producto";
            }
            else if (oEntradas.OpInventario_Cantidad == 0)
            {
                Mensaje = "Debe Ingresar Cantidad de productos que Entran ";
            }
            else if (oEntradas.IdUsuario == "0")
            {
                Mensaje = "Error Al Agregar Entrada, No esta asociado un Usuario";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.RegistrarEntrada(oEntradas, out Mensaje).Item2;
            }
            else
            {
                return 0;
            }

        }

        public int RegistrarSalida(Salidas oSalidas, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (oSalidas.IdProducto == "0")
            {
                Mensaje = "Error Al Agregar Entrada, No esta asociado un producto";
            }
            else if (oSalidas.OpInventario_Cantidad == 0)
            {
                Mensaje = "Debe Ingresar Cantidad de productos que Entran ";
            }
            else if (oSalidas.IdUsuario == "0")
            {
                Mensaje = "Error Al Agregar Entrada, No esta asociado un Usuario";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.RegistrarSalida(oSalidas, out Mensaje).Item2;
            }
            else
            {
                return 0;
            }

        }

        public int RegistrarEntradaProducto_Existente(Entradas oEntradas, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (oEntradas.IdProducto == "0")
            {
                Mensaje = "Error Al Agregar Entrada, No esta asociado un producto";
            }
            else if (oEntradas.Cantidad == 0)
            {
                Mensaje = "Cantidad con la que se registró el producto";
            }
            else if (oEntradas.OpInventario_Cantidad == 0)
            {
                Mensaje = "Debe Ingresar Cantidad de productos que Entran ";
            }
            else if (oEntradas.IdUsuario == "0")
            {
                Mensaje = "Error Al Agregar Producto, No esta asociado un Usuario";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.RegistrarEntradaProducto_Existente(oEntradas, out Mensaje).Item2;
            }
            else
            {
                return 0;
            }

        }

    }
}
