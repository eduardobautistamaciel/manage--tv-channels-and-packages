using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sd:Paquete
    {
        //atributos
        private bool mejorImagen;

        //parametros
        public bool MejorImagen
        {
            get { return mejorImagen; }
            set { mejorImagen = value; }
        }

        public Sd(bool mejorImagen, bool promocion, decimal precioBase, string nombre) : base(nombre, promocion, precioBase)//constructor
        {
            this.mejorImagen = mejorImagen;
        }

        public override bool TienePromocion()
        {
            return Promocion;
        }

        public override decimal PrecioPaquete()// metodo para saber precio de paquete sd
        {
            if (MejorImagen)
            {
                PrecioBase = ((PrecioBase * 20) / 100) + PrecioBase;
            }
            if (TienePromocion())
            {
                PrecioBase = PrecioBase * 15 / 100;
            }
            return PrecioBase;
        }

        public override int Tipo()//valida que resolucion sea 576
        {
            return 576;
        }
    }
}