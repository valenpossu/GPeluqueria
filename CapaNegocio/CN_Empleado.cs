using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Empleado
    {
        //instancia de la capa datos donde estan los metodos; asi podemos acceder a todos sus metodos
        private CD_Empleado objCapaDato = new CD_Empleado();

        public List<Empleado> listar()
        {
            return objCapaDato.listar();
        }

        public int Registrar(Empleado oEmpleado, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(oEmpleado.Nombre) && string.IsNullOrWhiteSpace(oEmpleado.Nombre))
            {
                Mensaje = "Nombre de Empleado No Puede Ser Vacio";
            }
            else if (string.IsNullOrEmpty(oEmpleado.Apellido) && string.IsNullOrWhiteSpace(oEmpleado.Apellido))
            {
                Mensaje = "Apellido del Empleado No Puede Ser Vacio";
            }
            else if (oEmpleado.Salario == 0)
            {
                Mensaje = "Debe Ingresar Un Valor Para El Salario";
            }
            else if (string.IsNullOrEmpty(oEmpleado.Correo) && string.IsNullOrWhiteSpace(oEmpleado.Correo))
            {
                Mensaje = "Correo del Empleado No Puede Ser Vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                string Clave = CN_Recursos.GenerarClave();
                string Asunto = "Creacion Cuenta Empleado 'GestionPeluqueria'";
                string mensaje_correo = "<h3>Su cuenta fue creada con exito</h3><br><p>Su contraseña para acceder es !clave!</p>";
                mensaje_correo = mensaje_correo.Replace("!clave!", Clave);

                bool respuesta = CN_Recursos.EnviarCorreo(oEmpleado.Correo, Asunto, mensaje_correo);

                if (respuesta) //validar si se envia el correo
                {
                    oEmpleado.Clave = CN_Recursos.ConvertirSha256(Clave);

                    return objCapaDato.Registrar(oEmpleado, out Mensaje);
                }
                else
                {
                    Mensaje = "No se puede enviar el correo";
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public bool Editar(Empleado oEmpleado, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(oEmpleado.Nombre) && string.IsNullOrWhiteSpace(oEmpleado.Nombre))
            {
                Mensaje = "Nombre de Empleado No Puede Ser Vacio";
            }
            else if (string.IsNullOrEmpty(oEmpleado.Apellido) && string.IsNullOrWhiteSpace(oEmpleado.Apellido))
            {
                Mensaje = "Apellido del Empleado No Puede Ser Vacio";
            }
            else if (oEmpleado.Salario == 0)
            {
                Mensaje = "Debe Ingresar Un Valor Para El Salario";
            }
            else if (string.IsNullOrEmpty(oEmpleado.Correo) && string.IsNullOrWhiteSpace(oEmpleado.Correo))
            {
                Mensaje = "Correo del Empleado No Puede Ser Vacio";
            }

            if (string.IsNullOrEmpty(Mensaje)) //si el mensaje despues de las validaciones sigue vacion es porque no hay ningun error
            {
                return objCapaDato.Editar(oEmpleado, out Mensaje);
            }
            else
            {
                return false;
            }
        }

    }
}
