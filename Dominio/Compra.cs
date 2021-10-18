using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        private DateTime fecha = DateTime.Today;
        private DateTime fechaVencimiento = DateTime.Today.AddYears(1);
        private List<Paquete> paquete = new List<Paquete>();
        private Usuario usuario;

        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public DateTime FechaVencimiento
        {
            get { return fechaVencimiento; }
            set { fechaVencimiento = value; }
        }

        public List<Paquete> Paquete
        {
            get { return paquete; }
            set { paquete = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public Compra()
        {

        }

        public Compra(DateTime fecha, DateTime fechaVencimiento, List<Paquete> paquete, Usuario usuario)
        {
            this.fecha = fecha;
            this.fechaVencimiento = fechaVencimiento;
            this.paquete = paquete;
            this.usuario = usuario;
        }

        public decimal Total()
        {
            decimal total = 0;
            foreach(Paquete unP in paquete)
            {
                total += unP.PrecioBase;
            }
            return total;
        }
    }
}
