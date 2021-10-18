using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;

namespace Obligatorio2.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Login(string mensaje)
        {
            ViewBag.Msj = mensaje;
            return View();
        }

        [HttpPost]
        public ActionResult Login(int cedula, string contrasenia)
        {
            Usuario unU = Sistema.Instancia.BuscarUsuario(cedula, contrasenia);
            if (unU != null && unU.Rol == "Cliente" )
            {
                Session["LogueadoCliente"] = unU;
                Session["LogueadoCedula"] = unU.Cedula;
                Session["LogueadoRol"] = unU.Rol;
                Session["Logueado"] = true;
                return Redirect("/paquete/index");
            }
            if (unU != null && unU.Rol == "Operador")
            {
                Session["LogueadoCedula"] = unU.Cedula;
                Session["LogueadoRol"] = unU.Rol;
                Session["Logueado"] = true;
                return Redirect("/usuario/operador");
            }
            else
            {
                ViewBag.mensaje = "Error de login";
            }
            return View();
        }

        public ActionResult Registrarse()
        {
          return View(new Usuario());
        }

        [HttpPost]
        public ActionResult Registrarse(Usuario usuario)
        {
            if (Sistema.Instancia.AgregarUsuario(usuario))
            {
                return RedirectToAction("login", new { mensaje = "Se registro correctamente" });
            }
            ViewBag.Mensaje = "Ocurrio un error al registrarse, intente nuevamente";
            return View(usuario);
        }

        public ActionResult Operador(string mensaje)
        {
            if ((string) Session["LogueadoRol"] != "Operador")
            {
                return Redirect("/usuario/login");
            }
            ViewBag.usuarios = Sistema.Instancia.ListaClientes();
            ViewBag.paqueteMasCaro = Sistema.Instancia.PaqueteMayorValor();
            ViewBag.comprasVencen = Sistema.Instancia.ClientesCompras();
            ViewBag.Mensaje = mensaje;
            return View();
        }

        public ActionResult ComprasPorFecha(DateTime fecha1, DateTime fecha2)
        {
            if ((string)Session["LogueadoRol"] != "Operador")
            {
                return Redirect("/usuario/login");
            }
            ViewBag.comprasFecha = Sistema.Instancia.ComprasPorFecha(fecha1, fecha2);
            return View();
        }

        public ActionResult BuscarCanal(string nombre)
        {
            if ((string)Session["LogueadoRol"] != "Operador")
            {
                return Redirect("/usuario/login");
            }
            if (Sistema.Instancia.CanalEnPaquetes(nombre).Count == 0) // ver si lista es 0
            {
                return RedirectToAction("Operador", new { mensaje = "No existe paquetes con el nombre de canal ingresado" });
            }
            ViewBag.nombreCanal = nombre;
            ViewBag.paquetesConCanales = Sistema.Instancia.CanalEnPaquetes(nombre);
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect("/paquete/index");
        }
    }
}