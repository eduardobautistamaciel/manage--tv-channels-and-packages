using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        #region atributos
        private static Sistema instancia;
        private List<Paquete> paquetes;
        private List<Canal> canales;
        private List<Usuario> usuarios;
        private List<Compra> compras;

        public static Sistema Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Sistema();
                }
                return instancia;
            }
        }
        #endregion

        public Sistema()
        {
            usuarios = new List<Usuario>();
            compras = new List<Compra>();
            paquetes = new List<Paquete>();
            canales = new List<Canal>();
            PrecargaCanales();
            PrecargaPaquetesHd();
            PrecargaPaquetesSd();
            PrecargaAsignarPaquete();
            PrecargarUsuarios();
            PrecargaCompra();
        }

        #region precargas
        private void PrecargaCanales() // precarga de 10 canales (5 de resolución 576 y 5 de resolución 1080)
        {
            AgregarCanal("Canal1-SD", 576, true, 1000);
            AgregarCanal("Canal2-SD", 576, false, 145);
            AgregarCanal("Canal3-SD", 576, true, 1564);
            AgregarCanal("Canal4-SD", 576, false, 11212);
            AgregarCanal("Canal5-SD", 576, true, 111);
            AgregarCanal("Canal6-HD", 1080, true, 1120);
            AgregarCanal("Canal7-HD", 1080, false, 1578);
            AgregarCanal("Canal8-HD", 1080, false, 3558);
            AgregarCanal("Canal9-HD", 1080, true, 7878);
            AgregarCanal("Canal10-HD", 1080, true, 1232);
            AgregarCanal("Canal11", 600, true, 1232);// da error porque no es ni 1080 ni 576
            AgregarCanal("", 1080, true, 1232);//da error sin nombre de canal
            AgregarCanal("Canal12", 1080, true, 0);//da error por precio 0
        }

        private void PrecargaPaquetesHd()//precarga 4 paquetes hd (letra pide 8 en total) 
        {
            AgregarPaqueteHd(false, true, 300, "PaqueteHD1");
            AgregarPaqueteHd(false, false, 400, "PaqueteHD2");
            AgregarPaqueteHd(true, false, 250, "PaqueteHD3");
            AgregarPaqueteHd(true, true, 750, "PaqueteHD4");
            AgregarPaqueteHd(true, true, 570, "PaqueteHD5");
            AgregarPaqueteHd(true, true, 750, "PaqueteHD6");
        }

        private void PrecargaPaquetesSd()//precarga 4 paquetes sd (letra pide 8 en total)
        {
            AgregarPaqueteSd(true, true, 100, "PaqueteSD1");
            AgregarPaqueteSd(false, true, 250, "PaqueteSD2");
            AgregarPaqueteSd(false, false, 400, "PaqueteSD3");
            AgregarPaqueteSd(true, false, 300, "PaqueteSD4");
            AgregarPaqueteSd(true, false, 300, "PaqueteSD5");
        }

        private void PrecargaAsignarPaquete()//precargo paquetes y canales
        {
            AsignarPaquete("Canal1-SD", 7);
            AsignarPaquete("Canal2-SD", 7);
            AsignarPaquete("Canal3-SD", 8);
            AsignarPaquete("Canal4-SD", 9);
            AsignarPaquete("Canal5-SD", 10);
            AsignarPaquete("Canal6-HD", 1);
            AsignarPaquete("Canal7-HD", 1);
            AsignarPaquete("Canal8-HD", 2);
            AsignarPaquete("Canal9-HD", 3);
            AsignarPaquete("Canal10-HD", 4);
        }

        private void PrecargarUsuarios()//precarga de usuarios operadores
        {
            Usuario unU;
            unU = new Usuario(2222222, "Carlos", "Sosa", "12345Af", "Cliente");
            usuarios.Add(unU);//precarga de cliente para ejercicio de operador compras vencen 30 dias


            unU = new Usuario(1234567, "", "", "12345Ad", "Operador");
            usuarios.Add(unU);
            unU = new Usuario(2345678, "", "", "12345As", "Operador");
            usuarios.Add(unU);
        }

        private void PrecargaCompra()//precargamos compras para ejercicio de operador
        {
            Compra unC;
            unC = new Compra(DateTime.Today, DateTime.Today.AddDays(30), paquetes, usuarios[0]);
            AgregarCompra(unC);
        }
        #endregion

        #region listado

        public List<Canal> Canales()//lista completa de canales
        {
            List<Canal> aux = new List<Canal>();
            for (int i = 0; i < canales.Count; i++)
            {
                aux.Add(canales[i]);
            }
            return aux;
        }

        public List<Paquete> Paquetes()//lista completa de paquetes
        {
            List<Paquete> aux = new List<Paquete>();
            for (int i = 0; i < paquetes.Count; i++)
            {
                aux.Add(paquetes[i]);
            }
            return aux;
        }

        public List<Paquete> CanalesHd()//lista paquete filtrada por hd
        {
            List<Paquete> aux = new List<Paquete>();
            foreach (Paquete UnHd in paquetes)
            {
                if (UnHd.Tipo() == 1080)
                {
                    aux.Add(UnHd);
                }
            }
            return aux;
        }

        public List<Paquete> CanalesSd()//lista paquete filtrada por sd
        {
            List<Paquete> aux = new List<Paquete>();
            foreach (Paquete UnSd in paquetes)
            {
                if (UnSd.Tipo() == 576)
                {
                    aux.Add(UnSd);
                }
            }
            return aux;
        }

        public List<Paquete> PaquetesListaDeValorDado(int tope)//lista paquete filtrada por un valor dado
        {
            List<Paquete> aux = new List<Paquete>();
            foreach (Paquete unPaquete in paquetes)
            {
                if (unPaquete.PrecioBase > tope)
                {
                    aux.Add(unPaquete);
                }
            }
            return aux;
        }

        public List<Paquete> PaqueteMasCanales()//lista filtrada por paquete con mas canales
        {
            int mayor = int.MinValue;
            List<Paquete> aux = new List<Paquete>();
            int cantidad;
            foreach (Paquete unPaquete in paquetes)
            {
                cantidad = unPaquete.CantidadCanales();
                if (cantidad > mayor)
                {
                    mayor = cantidad;
                    aux.Clear();
                    aux.Add(unPaquete);
                }
                else if (cantidad == mayor)
                {
                    aux.Add(unPaquete);
                }
            }
            return aux;
        }

        public List<Paquete> PaquetePorValor(int valor)//lista filtrada paquete por valor dado
        {
            List<Paquete> aux = new List<Paquete>();
            foreach (Paquete unPaquete in paquetes)
            {
                if (unPaquete.PrecioBase > valor)
                {
                    aux.Add(unPaquete);
                }
            }
            return aux;
        }
        //FIN OBLIGATORIO 1



        public List<Compra> ComprasPorFecha(DateTime fecha1, DateTime fecha2)//falta completar ejercicios
        {
            List<Compra> aux = new List<Compra>();
            foreach (Compra unaCompra in compras)
            {
                if (unaCompra.Fecha >= fecha1 && unaCompra.Fecha <= fecha2)
                {
                    aux.Add(unaCompra);
                }
            }
            return aux;
        }

        public List<Usuario> ListaClientes()//lista a todos los clientes dentro de usuarios
        {
            List<Usuario> aux = new List<Usuario>();
            foreach (Usuario unUs in usuarios)
            {
                if (unUs.Rol == "Cliente")
                {
                    aux.Add(unUs);
                }
            }
            aux.Sort();
            return aux;
        }

        public List<Paquete> CanalEnPaquetes(string nombre)//lista de paquetes por canal dado
        {
            List<Paquete> aux = new List<Paquete>();
            foreach (Paquete unP in paquetes)
            {
                foreach (Canal unC in unP.Canal)
                {
                    if (unC.Nombre == nombre)
                    {
                        aux.Add(unP);
                    }
                }
            }
            return aux;
        }

        public List<Paquete> PaqueteMayorValor()//lista paquetes mas caros
        {
            decimal mayor = int.MinValue;
            List<Paquete> aux = new List<Paquete>();
            foreach (Paquete unP in paquetes)
            {
                if (unP.PrecioBase > mayor)
                {
                    mayor = unP.PrecioBase;
                    aux.Clear();
                    aux.Add(unP);
                }
                else
                {
                    if(unP.PrecioBase == mayor)
                    {
                        aux.Add(unP);
                    }
                }
            }
            return aux;
        }

        public List<Paquete> PaquetesCompras(int cedula)//lista de paquetes comprados segun cliente
        {
            List<Paquete> aux = new List<Paquete>();
            foreach (Compra unC in compras)
            {
                if (unC.Usuario.Cedula == cedula)
                {
                    foreach (Paquete unP in unC.Paquete)
                    {
                        aux.Add(unP);
                    }
                }
            }
            return aux;
        }

        public List<Usuario> ClientesCompras()//lista de clientes que tengan compras cuyo vencimiento sea en los próximos 30 días o menos.
        {
            List<Usuario> aux = new List<Usuario>();
            foreach(Compra unC in compras)
            {
                if(unC.FechaVencimiento <= DateTime.Today.AddDays(30))
                {
                    aux.Add(unC.Usuario);
                }
            }
            return aux;
        }
        #endregion

        #region acciones con objetos

        public string AgregarCanal(string nombre, int resolucionImagen, bool multilenguaje, decimal precio)//toma los valor y al pasar validacion agrega a la lista el objeto canal
        {
            string respuesta = "";
            if (Canal.ValidarNombre(nombre) && Canal.ValidarResolucion(resolucionImagen) && Canal.ValidarPrecio(precio))//validacion 
            {
                Canal unCanal = new Canal(nombre, resolucionImagen, multilenguaje, precio);// crea el objeto canal
                canales.Add(unCanal);//agrega a la lista
                respuesta = "Canal ingresado con exito!!!";
            }
            else
            {
                respuesta = "Hubo un error en los datos ingresado, el canal NO fue creado.";
            }
            return respuesta;
        }

        public bool AgregarPaqueteHd(bool tieneNube, bool promocion, decimal precioBase, string nombre)//toma los valor y al pasar validacion agrega a la lista el objeto paquete hd
        {
            bool exito = false;
            if (Paquete.ValidarPrecio(precioBase) && Paquete.ValidarNombre(nombre))//validacion 
            {
                Hd unHd = new Hd(tieneNube, promocion, precioBase, nombre);// crea el objeto canal
                paquetes.Add(unHd);
                exito = true;
            }
            return exito;
        }

        public bool AgregarPaqueteSd(bool mejorImagen, bool promocion, decimal precioBase, string nombre)//toma los valor y al pasar validacion agrega a la lista el objeto paquete sd
        {
            bool exito = false;
            if (Paquete.ValidarPrecio(precioBase) && Paquete.ValidarNombre(nombre))//validacion 
            {
                Sd unSd = new Sd(mejorImagen, promocion, precioBase, nombre);// crea el objeto canal
                paquetes.Add(unSd);
                exito = true;
            }
            return exito;
        }

        public Paquete BuscarPaquete(int id)//busqueda de paquete por id
        {
            Paquete unPaquete = null;
            int i = 0;
            while (unPaquete == null && i < paquetes.Count)
            {
                if (paquetes[i].Id == id)
                {
                    unPaquete = paquetes[i];
                }
                i++;
            }
            return unPaquete;
        }

        public Paquete BuscarPaquete(string nombre)//busqueda de paquete por nombre
        {
            Paquete unPaquete = null;
            int i = 0;
            while (unPaquete == null && i < paquetes.Count)
            {
                if (paquetes[i].Nombre == nombre)
                {
                    unPaquete = paquetes[i];
                }
                i++;
            }
            return unPaquete;
        }

        public Canal BuscarCanal(string nombre)//busqueda de paquete por nombre
        {
            Canal unCanal = null;
            int i = 0;
            while (unCanal == null && i < canales.Count)
            {
                if (canales[i].Nombre == nombre)
                {
                    unCanal = canales[i];
                }
                i++;
            }
            return unCanal;
        }

        public Canal BuscarCanal(int id)//busqueda de paquete por id
        {
            Canal unCanal = null;
            int i = 0;
            while (unCanal == null && i < canales.Count)
            {
                if (canales[i].Id == id)
                {
                    unCanal = canales[i];
                }
                i++;
            }
            return unCanal;
        }

        public bool AsignarPaquete(string nombre, int id)//asigno canales a paquetes
        {
            bool exito = false;
            Canal unCanal = BuscarCanal(nombre);
            Paquete unPaquete = BuscarPaquete(id);
            if (unCanal != null && unCanal.ResolucionImagen == 1080)
            {
                if (unPaquete != null && unPaquete.Tipo() == 1080)
                {
                    unPaquete.Canal.Add(unCanal);
                    exito = true;
                }
            }

            if (unCanal != null && unCanal.ResolucionImagen == 576)
            {
                if (unPaquete != null && unPaquete.Tipo() == 576)
                {
                    unPaquete.Canal.Add(unCanal);
                    exito = true;
                }
            }
            return exito;
        }
        //FIN OBLIGATORIO 1


        public bool AgregarUsuario(Usuario usuario)//valida para agregar usuario
        {
            bool exito = false;
            if (Usuario.ValidarCedula(usuario.Cedula) && Usuario.ValidarNombre(usuario.Nombre) && Usuario.ValidarApellido(usuario.Apellido) && Usuario.ValidarContrasenia(usuario.Contrasenia))
            {
                if (Usuario.ValidarRol(usuario.Rol))
                {
                    usuario.Rol = "Cliente";
                }
                if (BuscarCedula(usuario.Cedula))
                {
                    usuarios.Add(usuario);
                    exito = true;
                }

            }
            return exito;
        }

        public bool BuscarCedula(int cedula)//busca si la cedula ya existe
        {
            bool exito = true;
            foreach (Usuario unUs in usuarios)
            {
                if(unUs.Cedula == cedula)
                {
                    exito = false;
                }
            }
            return exito;
        }

        public Usuario BuscarUsuario(int cedula, string contrasenia)//busca usuario con cedula y contrasenia
        {
            Usuario usuario = null;
            int i = 0;
            while (usuario == null && i < usuarios.Count)
            {
                Usuario unS = usuarios[i];
                if (unS.Cedula == cedula && unS.Contrasenia == contrasenia)
                {
                    usuario = unS;
                }
                i++;
            }
            return usuario;
        }

        public bool AgregarCompra(Compra compra)//agregar compra a la lista compras
        {
            bool exito = false;
            if (true)
            {
                compras.Add(compra);
                exito = true;
            }
            return exito;
        }

        public Usuario BuscarCliente(int cedula)//busca cliente dentro de lista usuario
        {
            Usuario usuario = null;
            int i = 0;
            while (usuario == null && i < usuarios.Count)
            {
                Usuario unS = usuarios[i];
                if (unS.Cedula == cedula && unS.Rol == "Cliente")
                {
                    usuario = unS;
                }
                i++;
            }
            return usuario;
        }

        public bool AsignarPaqueteCompra(Compra compra, Paquete paquete)//asigna paquetes a compras
        {
            bool exito = false;
            Compra unC = compra;
            Paquete unP = paquete;
            if (true)
            {
                unC.Paquete.Add(unP);
            }
           
            return exito;
        }

        public bool CancelarPaquete(Paquete paquete, Usuario usuario)//cancela paquete dentro de la compra 
        {
            bool exito = false;
            int i = 0;
            while (exito == false && i < compras.Count)
            {
                if (compras[i].Usuario == usuario)
                {
                    int x = 0;
                    while (exito == false && x < compras[i].Paquete.Count)
                    {
                        if (compras[i].Paquete[x] == paquete)
                        {
                            compras.Remove(compras[i]);
                            exito = true;
                        }
                        x++;
                    }
                }
                i++;
            }
            return exito;
        }
        #endregion
    }
}