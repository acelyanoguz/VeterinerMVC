using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeterinerMVC.Models.EntityFramework;

namespace VeterinerMVC.Controllers
{
    public class HastaKartiController : Controller
    {
        HastaTakipEntities db = new HastaTakipEntities();
        // GET: HastaKarti
        public ActionResult Index(Hayvan hayvan, int HayvanID = 0)
        {
            Hayvan h = new Hayvan();            
            if (HayvanID != 0)
            {
                h = db.Hayvan.Where(x => x.HayvanID == HayvanID).FirstOrDefault();
            }
            else
            {
                h = hayvan;
            }     
            return View(h);
        }
        public ActionResult Sil(int id)
        {
            var hayvnsil = db.Hayvan.Find(id);
            db.Hayvan.Remove(hayvnsil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult HastaGetir(int id)
        {
            var hst = db.Hayvan.Find(id);
            return View("HastaGetir", hst);
        }
        public ActionResult Guncelle(Hayvan p1)
        {
            
            var gncl = db.Hayvan.Find(p1.HayvanID);
            gncl.HayvanAdi = p1.HayvanAdi;
            gncl.HayvanTuru = p1.HayvanTuru;
            gncl.Cinsiyeti = p1.Cinsiyeti;
            gncl.HayvanIrki = p1.HayvanIrki;
            gncl.HayvanYasi = p1.HayvanYasi;
            db.SaveChanges();
            return View("Index", gncl );
        }
       

    }
}