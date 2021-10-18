using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Paquete
    {
        //atributos
        private int id;
        private static int ultId;
        private string nombre;
        private List<Canal> canal = new List<Canal>();
        private bool promocion;
        private decimal precioBase;

        //parametros
        public decimal PrecioBase
        {
            get { return precioBase; }
            set { precioBase = value; }
        }

        public bool Promocion
        {
            get { return promocion; }
        }

        public List<Canal> Canal
        {
            get { return canal; }
            set { canal = value; }
        }

        public string Nombre
        {
            get { return nombre; }
        }

        public int Id
        {
            get { return id; }
        }

        public Paquete(string nombre, bool promocion, decimal precioBase)//constructor
        {
            this.id = ++ultId;
            this.nombre = nombre;
            this.promocion = promocion;
            this.precioBase = precioBase;
        }

        public static bool ValidarNombre(string nombre)//valida que sea mayor a 0
        {
            return nombre.Length > 0;
        }

        public static bool ValidarPrecio(decimal precio)//valida que el precio sea mayor a 0
        {
            return precio > 0;
        }

        public int CantidadCanales()//conteo de canales en lista
        {
            return canal.Count;
        }

        public override string ToString()//creacion de la muestra en consola
        {
            string respuesta = "";
            respuesta += "Id:" + id + "\n";
            respuesta += "Nombre:" + nombre + "\n";
            respuesta += "Promocion:" + promocion + "\n";
            respuesta += "Precio base:" + precioBase + "\n";
            respuesta += "\n";
            respuesta += "Canales:\n";
            foreach (Canal unCanal in canal)
            {
                respuesta += unCanal + "\n";
            }
            respuesta += "------------------------";
            return respuesta;
        }

        //metodos abstractos
        public abstract bool TienePromocion();
        public abstract decimal PrecioPaquete();
        public abstract int Tipo();
    }
}
