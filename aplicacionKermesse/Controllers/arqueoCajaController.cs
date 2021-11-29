using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aplicacionKermesse.Models;
using System.Data.Entity;

namespace aplicacionKermesse.Controllers
{
    public class arqueoCajaController : Controller
    {
        private BD_KermesseEntities db = new BD_KermesseEntities();
        public ActionResult Index()
        {
            
            return View(db.tbl_arqueocaja.ToList());
        }

        public ActionResult verArqueo()
        {
            List<tbl_arqueocaja_det> listaArqueoDetalle = db.tbl_arqueocaja_det.ToList();
            return View();
        }

        public ActionResult guardarArqueo()
        {
            return View();
        }

        public ActionResult VerArqueoCaja(int id)
        {
            var denom = db.tbl_arqueocaja.Where(x => x.id_arqueocaja == id).First();
            return View(denom);
        }

        public ActionResult guardarArqueoCaja()
        {
            return View();
        }
    }
}