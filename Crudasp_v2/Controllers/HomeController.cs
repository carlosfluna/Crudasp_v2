using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Crudasp_v2.Models;

namespace Crudasp_v2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            MantenimientoArticulos ma = new MantenimientoArticulos();
            return View(ma.RecuperarTodos());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            MantenimientoArticulos ma = new MantenimientoArticulos();
            Articulo art = ma.Recuperar(id);
            return View(art);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            MantenimientoArticulos ma = new MantenimientoArticulos();
            Articulo art = new Articulo
            {
                Codigo = int.Parse(collection["codigo"]),
                Descripcion = collection["descripcion"],
                Precio = float.Parse(collection["precio"].ToString())
            };
            ma.Alta(art);
            return RedirectToAction("Index");
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            MantenimientoArticulos ma = new MantenimientoArticulos();
            Articulo art = ma.Recuperar(id);
            return View(art);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            MantenimientoArticulos ma = new MantenimientoArticulos();
            Articulo art = new Articulo
            {
                Codigo = id,
                Descripcion = collection["descripcion"].ToString(),
                Precio = float.Parse(collection["precio"].ToString())
            };
            ma.Modificar(art);
            return RedirectToAction("Index");
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            MantenimientoArticulos ma = new MantenimientoArticulos();
            Articulo art = ma.Recuperar(id);
            return View(art);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            MantenimientoArticulos ma = new MantenimientoArticulos();
            ma.Borrar(id);
            return RedirectToAction("Index");
        }
    }
}
