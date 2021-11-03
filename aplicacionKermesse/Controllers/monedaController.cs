using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aplicacionKermesse.Models;
using System.Data.Entity;

namespace aplicacionKermesse.Controllers
{
    public class monedaController : Controller
    {
        private BD_KermesseEntities db = new BD_KermesseEntities();
        // GET: moneda
        public ActionResult moneda()
        {
            return View(db.tbl_moneda.ToList());
        }

        public ActionResult guardarMoneda()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(tbl_moneda tcM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbl_moneda tcMoneda = new tbl_moneda();
                    tcMoneda.nombre = tcM.nombre;
                    tcMoneda.signo = tcM.signo;
                    tcMoneda.estado = 1;
                    db.tbl_moneda.Add(tcMoneda);
                    db.SaveChanges();
                }
                ModelState.Clear();
            }
            catch (Exception e)
            {
                throw e;
            }
            var list = db.tbl_moneda.ToList();
            return View("moneda", list);
        }

        public ActionResult borrarMoneda(int id)
        {
            tbl_moneda Tmon = new tbl_moneda();
            Tmon = db.tbl_moneda.Find(id);
            db.tbl_moneda.Remove(Tmon);

            db.SaveChanges();

            var list = db.tbl_moneda.ToList();
            return View("moneda", list);
        }

        public ActionResult VerMoneda(int id)
        {
            var mon = db.tbl_moneda.Where(x => x.id_moneda == id).First();
            return View(mon);
        }

        public ActionResult EditarMoneda(int id)
        {
            tbl_moneda tMon = db.tbl_moneda.Find(id);
            if(tMon == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tMon);
            }
        }
        [HttpPost]
        public ActionResult ActualizarMoneda(tbl_moneda tMon)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tMon.estado = 2;
                    db.Entry(tMon).State = EntityState.Modified;
                    db.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("moneda");
            }
            catch (Exception e)
            {
                throw e;
                return View();
            }
        }

        [HttpPost]
        public ActionResult FiltrarMoneda(String cadena)
        {
            if (String.IsNullOrEmpty(cadena))
            {
                var list = db.tbl_moneda.ToList();
                return View("moneda", list);
            }
            else
            {
                var listaFiltrada = db.tbl_moneda.Where(x => x.nombre.Contains(cadena) || x.signo.Contains(cadena));
                return View("moneda", listaFiltrada);
            }
        }
    }
}