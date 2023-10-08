using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeterinerMVC.Models.EntityFramework;

namespace VeterinerMVC.Controllers
{
    public class AsiController : Controller
    {
        HastaTakipEntities db = new HastaTakipEntities();
        // GET: Asi
        public ActionResult Index(AsiTakvimi p2,int HayvanID)
        {
            string kullaniciid = Session["id"].ToString();
            int a = Convert.ToInt32(kullaniciid);
            var asilar = AsiTakvimi.asilar;
            if (HayvanID!=0)
            {
                asilar = db.AsiTakvimi.Where(x => x.KullaniciID == a && x.HayvanID==HayvanID).ToList();
            }
            else
            {
                asilar = db.AsiTakvimi.Where(x => x.KullaniciID == a).ToList();// kullanıcıya özel
            }
            return View(asilar);
        }
        [HttpGet]
        public ActionResult YeniAsi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAsi(AsiTakvimi asi1,int HayvanID)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniAsi");// burda id sıfırsa diye yap bir 
            }
            int a = Convert.ToInt32(Session["id"]);
            asi1.KullaniciID = a;
            db.AsiTakvimi.Add(asi1);
            
            db.SaveChanges();
            return RedirectToAction("Index", "Asi", new { HayvanID = HayvanID });
        }
        public ActionResult Sil(int id)
        {
            var asil = db.AsiTakvimi.Find(id);
            db.AsiTakvimi.Remove(asil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AsiGetir(int id)
        {
            var asi = db.AsiTakvimi.Find(id);
            return View("AsiGuncelle", asi);
        }
        public ActionResult Guncelle(AsiTakvimi p1)
        {
            var guncelasi = db.AsiTakvimi.Find(p1.AsiID);
            guncelasi.YapilisTarihi = p1.YapilisTarihi;
            guncelasi.TekrarTarihi = p1.TekrarTarihi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}