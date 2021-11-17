using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aplicacionKermesse.Models;
using System.Data.Entity;

namespace aplicacionKermesse.Controllers
{
    public class gastoController : Controller
    {
        private BD_KermesseEntities db = new BD_KermesseEntities();
        // GET: gasto
        public ActionResult gasto()
        {
            return View(db.tbl_gastos.ToList());
        }

        [HttpPost]
        public ActionResult FiltrarGasto(String cadena)
        {
            if (String.IsNullOrEmpty(cadena))
            {
                var list = db.tbl_gastos.ToList();
                return View("gasto", list);
            }
            else
            {
                var listaFiltrada = db.tbl_gastos.Where(x => x.concepto.Contains(cadena) || x.monto.ToString().Contains(cadena));
                return View("gasto", listaFiltrada);
            }
        }

        public ActionResult guardarGasto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(tbl_gastos tbG)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbl_gastos tbGasto = new tbl_gastos();
                    tbGasto.id_cat_gasto = tbG.id_cat_gasto;
                    tbGasto.id_kermesse = tbG.id_kermesse;
                    tbGasto.fecha_gasto = tbG.fecha_gasto;
                    tbGasto.concepto = tbG.concepto;
                    tbGasto.monto = tbG.monto;
                    tbGasto.estado = 1;
                    db.tbl_gastos.Add(tbGasto);
                    db.SaveChanges();
                }
                ModelState.Clear();
            }
            catch (Exception e)
            {
                throw e;
            }
            var list = db.tbl_gastos.ToList();
            return View("gasto", list);
        }

        public ActionResult borrarGasto(int id)
        {
            tbl_gastos Tgas = new tbl_gastos();
            Tgas = db.tbl_gastos.Find(id);
            db.tbl_gastos.Remove(Tgas);

            db.SaveChanges();

            var list = db.tbl_gastos.ToList();
            return View("gasto", list);
        }

        public ActionResult VerGasto(int id)
        {
            var denom = db.tbl_gastos.Where(x => x.id_gasto == id).First();
            return View(denom);
        }

        public ActionResult EditarGasto(int id)
        {
            tbl_gastos tGasto = db.tbl_gastos.Find(id);
            if (tGasto == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tGasto);
            }
        }

        [HttpPost]
        public ActionResult ActualizarGasto(tbl_gastos tGast)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tGast.estado = 2;
                    db.Entry(tGast).State = EntityState.Modified;
                    db.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("gasto");
            }
            catch (Exception e)
            {
                throw e;
                return View();
            }
        }
    }
}