using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crudasp_v2.Models;

namespace Crudasp_v2.Controllers
{
    public class BuscarController : Controller
    {
        // GET: Buscar
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection coleccion)
        {
            MantenimientoArticulos ma = new MantenimientoArticulos();
            Articulo art = ma.Recuperar(int.Parse(coleccion["Codigo"].ToString()));

            if (art != null)
                return View("ModificacionArticulo", art);
            else
                return View("ArticuloNoExistente");
        }
        [HttpPost]
        public ActionResult ModificacionArticulo(FormCollection coleccion)
        {
            MantenimientoArticulos ma = new MantenimientoArticulos();
            Articulo art = new Articulo
            {
                Codigo = int.Parse(coleccion["Codigo"].ToString()),
                Descripcion = coleccion["Descripcion"].ToString(),
                Precio = float.Parse(coleccion["Precio"].ToString())
            };
            ma.Modificar(art);
            return RedirectToAction("Index","Home");
        }
    }

}