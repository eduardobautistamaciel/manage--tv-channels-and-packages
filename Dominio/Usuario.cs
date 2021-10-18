using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario: IComparable<Usuario>
    {
        private int cedula;
        private string nombre;
        private string apellido;
        private string contrasenia;
        private string rol;

        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }


        public string Contrasenia
        {
            get { return contrasenia; }
            set { contrasenia = value; }
        }


        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }


        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public int Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        public Usuario()
        {

        }

        public Usuario(int cedula, string nombre, string apellido, string contrasenia, string rol)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellido = apellido;
            this.contrasenia = contrasenia;
            this.rol = rol;
        }

        public static bool ValidarCedula(int cedula)
        {
            return cedula.ToString().Length >= 7 && cedula.ToString().Length <= 9;
        }

        public static bool ValidarNombre(string nombre)
        {
            return nombre.Length >= 2;
        }

        public static bool ValidarApellido(string apellido)
        {
            return apellido.Length >= 2;
        }

        public static bool ValidarRol(string rol)
        {
            return rol == null;
        }

        //Valida que la contraseña tendrá un largo mínimo de 6 caracteres y
        //contendrá al menos una mayúscula, una minúscula y un dígito.
        public static bool ValidarContrasenia(string contrasenia)
        {
            bool contraseniaValido = false;
            bool mayor6 = contrasenia.Length >= 6;
            bool contieneMayuscula = contrasenia.Any(x => char.IsUpper(x));
            bool contieneMinuscula = contrasenia.Any(x => char.IsLower(x));
            bool contieneNumero = contrasenia.Any(c => char.IsDigit(c));
            if (mayor6 && contieneMayuscula && contieneMinuscula && contieneNumero)
            {
                contraseniaValido = true;
            }
            return contraseniaValido;
        }

        public int CompareTo(Usuario other)
        {
            Usuario unU = other as Usuario;
            int orden = Apellido.CompareTo(unU.Apellido);
            if (orden == 0)
            {
                orden = Nombre.CompareTo(unU.Nombre);
            }
            return orden;
        }
    }
}