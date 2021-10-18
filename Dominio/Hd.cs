using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Hd : Paquete
    {
        //atributos
        private static decimal costoFijo = 100;
        private bool tieneNube;

        //parametros
        public static decimal CostoFijo
        {
            get { return costoFijo; }
            set { costoFijo = value; }
        }

        public bool TieneNube
        {
            get { return tieneNube; }
            set { tieneNube = value; }
        }

        public Hd(bool tieneNube, bool promocion, decimal precioBase, string nombre) : base(nombre, promocion, precioBase)//constructor
        {
            this.tieneNube = tieneNube;
        }

        public override bool TienePromocion()//validacion si tiene promocion 
        {
            return Promocion;
        }

        public override decimal PrecioPaquete()// metodo para saber precio de paquete hd
        {
            if (TieneNube)
            {
                PrecioBase = +costoFijo;
            }
            if (TienePromocion())
            {
                PrecioBase = PrecioBase * 50 / 100;
            }
            return PrecioBase;
        }

        public static bool ValidarCostoFijo(decimal costoFijo)//valida que costo sea mayor a 0
        {
            return costoFijo > 0;
        }

        public override int Tipo()//valida que resolucion sea 1080
        {
            return 1080;
        }
    }
}