using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeterinerMVC.Models.EntityFramework;

namespace VeterinerMVC.Controllers
{
    public class TedaviController : Controller
    {
        HastaTakipEntities db = new HastaTakipEntities();
        // GET: Tedavi
        public ActionResult Index(int HayvanID)
        {
            string kullaniciid = Session["id"].ToString();
            int a = Convert.ToInt32(kullaniciid);
            var tedaviler = TedaviEkle.tedaviler;
            if (HayvanID != 0)
            {
                tedaviler = db.TedaviEkle.Where(x => x.KullaniciID == a && x.HayvanID==HayvanID).ToList();
            }
            else{
                tedaviler = db.TedaviEkle.Where(x => x.KullaniciID == a).ToList();// kullanıcıya özel
            }
             
            return View(tedaviler);
            
        }
        [HttpGet]
        public ActionResult YeniTedavi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniTedavi(TedaviEkle tdv1, int HayvanID)
        {
            if (!ModelState.IsValid)
            {
                return View ("YeniTedavi");
            }
            int a = Convert.ToInt32(Session["id"]);
            tdv1.KullaniciID = a;
            db.TedaviEkle.Add(tdv1);
            db.SaveChanges();
            return RedirectToAction("Index","Tedavi", new { HayvanID = HayvanID });
        }
        public ActionResult Sil(int id)
        {
            var tdvsil = db.TedaviEkle.Find(id);
            db.TedaviEkle.Remove(tdvsil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult TedaviGetir(int id)
        {
            var tdv = db.TedaviEkle.Find(id);
            return View("TedaviGetir", tdv);
        }
        public ActionResult Guncelle(TedaviEkle p1)
        {
            var gncltdv = db.TedaviEkle.Find(p1.TedaviID);
            gncltdv.HastalikAdi = p1.HastalikAdi;
            gncltdv.UygulananTedavi = p1.UygulananTedavi;
            db.SaveChanges();
            return View("Index");
        }
    }
}