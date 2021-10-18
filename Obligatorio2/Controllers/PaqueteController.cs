using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;

namespace Obligatorio2.Controllers
{
    public class PaqueteController : Controller
    {
        // GET: Paquete
        public ActionResult Index(string mensaje)
        {
            ViewBag.Msj = mensaje;
            ViewBag.listaPaquetes = Sistema.Instancia.Paquetes();
            return View();
        }

        public ActionResult ComprarPaquete(int? id)
        {
            if ((string)Session["LogueadoRol"] != "Cliente")
            {
                return Redirect("/usuario/login");
            }
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Paquete unP = Sistema.Instancia.BuscarPaquete((int)id);
            if (unP == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Paquete = unP;
            return View(new Compra());
        }

        [HttpPost]
        public ActionResult ComprarPaquete(Compra compra, int cedula, int id)
        {
            Usuario unUs = Sistema.Instancia.BuscarCliente(cedula);
            Paquete unP = Sistema.Instancia.BuscarPaquete(id);
            compra.Usuario = unUs;
            Sistema.Instancia.AsignarPaqueteCompra(compra, unP);
            if (Sistema.Instancia.AgregarCompra(compra))
            {
                return RedirectToAction("index", new { mensaje = "Se compro correctamente" });
            }
            ViewBag.Mensaje = "Ocurrio un error al comprar, intente nuevamente";
            return View(compra);
        }

        public ActionResult VerCompras()
        {
            if ((string)Session["LogueadoRol"] != "Cliente")
            {
                return Redirect("/usuario/login");
            }
            ViewBag.paquetesComprados = Sistema.Instancia.PaquetesCompras((int)Session["LogueadoCedula"]);
            return View();
        }

        public ActionResult CancelacionCompras(int id)
        {
            if ((string)Session["LogueadoRol"] != "Cliente")
            {
                return Redirect("/usuario/login");
            }
            Usuario unUs = Sistema.Instancia.BuscarCliente((int)Session["LogueadoCedula"]);
            Paquete unP = Sistema.Instancia.BuscarPaquete(id);
            ViewBag.cancelarCompra = Sistema.Instancia.CancelarPaquete(unP, unUs);
            ViewBag.paquetesComprados = Sistema.Instancia.PaquetesCompras((int)Session["LogueadoCedula"]);
            return View("VerCompras");
        }
    }
}