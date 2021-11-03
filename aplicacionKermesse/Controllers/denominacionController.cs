using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aplicacionKermesse.Models;
using System.Data.Entity;

namespace aplicacionKermesse.Controllers
{
    public class denominacionController : Controller
    {
        private BD_KermesseEntities db = new BD_KermesseEntities();
        // GET: denominacion
        public ActionResult denominacion()
        {
            return View(db.tbl_denominacion.ToList());
        }

        [HttpPost]
        public ActionResult FiltrarDenominacion(String cadena)
        {
            if (String.IsNullOrEmpty(cadena))
            {
                var list = db.tbl_denominacion.ToList();
                return View("denominacion", list);
            }
            else
            {
                var listaFiltrada = db.tbl_denominacion.Where(x => x.valor_letras.Contains(cadena));
                return View("denominacion", listaFiltrada);
            }
        }

        public ActionResult guardarDenominacion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(tbl_denominacion tbD)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbl_denominacion tbDenom = new tbl_denominacion();
                    tbDenom.id_moneda = tbD.id_moneda;
                    tbDenom.valor = tbD.valor;
                    tbDenom.valor_letras = tbD.valor_letras;
                    tbDenom.estado = 1;
                    db.tbl_denominacion.Add(tbDenom);
                    db.SaveChanges();
                }
                ModelState.Clear();
            }
            catch (Exception e)
            {
                throw e;
            }
            var list = db.tbl_denominacion.ToList();
            return View("denominacion", list);
        }

        public ActionResult borrarDenominacion(int id)
        {
            tbl_denominacion Tdenom = new tbl_denominacion();
            Tdenom = db.tbl_denominacion.Find(id);
            db.tbl_denominacion.Remove(Tdenom);

            db.SaveChanges();

            var list = db.tbl_denominacion.ToList();
            return View("denominacion", list);
        }

        public ActionResult VerDenominacion(int id)
        {
            var denom = db.tbl_denominacion.Where(x => x.id_denominacion == id).First();
            return View(denom);
        }

        public ActionResult EditarDenominacion(int id)
        {
            tbl_denominacion tDenom = db.tbl_denominacion.Find(id);
            if (tDenom == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tDenom);
            }
        }

        [HttpPost]
        public ActionResult ActualizarDenominacion(tbl_denominacion tDenom)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tDenom.estado = 2;
                    db.Entry(tDenom).State = EntityState.Modified;
                    db.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("denominacion");
            }
            catch (Exception e)
            {
                throw e;
                return View();
            }
        }
    }
}