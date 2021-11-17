using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aplicacionKermesse.Models;
using System.Data.Entity;

namespace aplicacionKermesse.Controllers
{
    public class categoriaGastoController : Controller
    {
        private BD_KermesseEntities db = new BD_KermesseEntities();
        // GET: categoriaGasto
        public ActionResult categoriaGasto()
        {
            return View(db.tbl_cat_gastos.ToList());
        }

        [HttpPost]
        public ActionResult FiltrarCategoriaGasto(String cadena)
        {
            if (String.IsNullOrEmpty(cadena))
            {
                var list = db.tbl_cat_gastos.ToList();
                return View("categoriaGasto", list);
            }
            else
            {
                var listaFiltrada = db.tbl_cat_gastos.Where(x => x.nombre_cat.Contains(cadena) || x.desc_cat.Contains(cadena));
                return View("categoriaGasto", listaFiltrada);
            }
        }

        public ActionResult guardarCategoriaGasto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(tbl_cat_gastos tbCG)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbl_cat_gastos tbCatGasto = new tbl_cat_gastos();
                    tbCatGasto.nombre_cat = tbCG.nombre_cat;
                    tbCatGasto.desc_cat = tbCG.desc_cat;
                    tbCatGasto.estado = 1;
                    db.tbl_cat_gastos.Add(tbCatGasto);
                    db.SaveChanges();
                }
                ModelState.Clear();
            }
            catch (Exception e)
            {
                throw e;
            }
            var list = db.tbl_cat_gastos.ToList();
            return View("categoriaGasto", list);
        }

        public ActionResult borrarCategoriaGasto(int id)
        {
            tbl_cat_gastos TcatG = new tbl_cat_gastos();
            TcatG = db.tbl_cat_gastos.Find(id);
            db.tbl_cat_gastos.Remove(TcatG);

            db.SaveChanges();

            var list = db.tbl_cat_gastos.ToList();
            return View("categoriaGasto", list);
        }

        public ActionResult VerCategoriaGasto(int id)
        {
            var catGasto = db.tbl_cat_gastos.Where(x => x.id_cat_gasto == id).First();
            return View(catGasto);
        }

        public ActionResult EditarCategoriaGasto(int id)
        {
            tbl_cat_gastos tbCatGasto = db.tbl_cat_gastos.Find(id);
            if (tbCatGasto == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tbCatGasto);
            }
        }

        [HttpPost]
        public ActionResult ActualizarCategoriaGasto(tbl_cat_gastos tbCatGasto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbCatGasto.estado = 2;
                    db.Entry(tbCatGasto).State = EntityState.Modified;
                    db.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("categoriaGasto");
            }
            catch (Exception e)
            {
                throw e;
                return View();
            }
        }
    }
}