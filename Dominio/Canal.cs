using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Canal
    {
        //atributos
        private int id;
        private static int ultId;
        private string nombre;
        private int resolucionImagen;
        private bool multilenguaje;
        private decimal precio;

        //parametros
        public decimal Precio
        {
            get { return precio; }
        }


        public bool Multilenguaje
        {
            get { return multilenguaje; }
        }


        public int ResolucionImagen
        {
            get { return resolucionImagen; }
        }


        public string Nombre
        {
            get { return nombre; }
        }

        public int Id
        {
            get { return id; }
        }

        public Canal(string nombre, int resolucionImagen, bool multilenguaje, decimal precio)//constructor
        {
            this.id = ++ultId;
            this.nombre = nombre;
            this.resolucionImagen = resolucionImagen;
            this.multilenguaje = multilenguaje;
            this.precio = precio;
        }


        public static bool ValidarNombre(string nombre)//valida que sea mayor a 0
        {
            return nombre.Length > 0;
        }

        public static bool ValidarResolucion(int resolucionImagen)// valida que sea una resolucion posible
        {
            return resolucionImagen == 576 || resolucionImagen == 1080;
        }

        public static bool ValidarPrecio(decimal precio)//valida que el precio sea mayor a 0
        {
            return precio > 0;
        }

        public override string ToString()//creacion de la muestra en consola
        {
            string respuesta = "";
            respuesta += "Id:" + id + "\n";
            respuesta += "Nombre:" + nombre + "\n";
            respuesta += "Resolucion de imagen:" + resolucionImagen + "\n";
            respuesta += "Multilenguaje:" + multilenguaje + "\n";
            respuesta += "Precio:" + precio + "\n";
            return respuesta;
        }
    }
}
