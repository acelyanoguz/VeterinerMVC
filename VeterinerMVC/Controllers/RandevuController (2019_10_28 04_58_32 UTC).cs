using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeterinerMVC.Models.EntityFramework;
namespace VeterinerMVC.Controllers
{
    public class RandevuController : Controller
    {
        HastaTakipEntities db = new HastaTakipEntities();
        // GET: Randevu
        public ActionResult Index(int HayvanID=0)
        {
            string kullaniciid = Session["id"].ToString();
            int a = Convert.ToInt32(kullaniciid);
            var randevular = Randevular.randevular;
            if (HayvanID!=0)
            {
                 randevular = db.Randevular.Where(x => x.KullaniciID == a && x.HayvanID == HayvanID).ToList();

            }
            else
            {
                randevular = db.Randevular.Where(x => x.KullaniciID == a).ToList();// kullanıcıya özel

            }
            return View(randevular);
        }
        [HttpGet]
        public ActionResult YeniRandevu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniRandevu(Randevular rndv1,int HayvanID)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniRandevu");
            }
            int a = Convert.ToInt32(Session["id"]);
            rndv1.KullaniciID = a;
            db.Randevular.Add(rndv1);
            db.SaveChanges();
            return RedirectToAction("Index", "Randevu", new { HayvanID = HayvanID });
        }
        public ActionResult Sil(int id)
        {
            var rndvsil = db.Randevular.Find(id);
            db.Randevular.Remove(rndvsil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public  ActionResult RandevuGetir(int id)
        {
            var rndv = db.Randevular.Find(id);
            return View("RandevuGetir", rndv);
        }
        public ActionResult Guncelle(Randevular p1)
        {
            var gncl = db.Randevular.Find(p1.RandevuID);
            gncl.RandevuID = p1.RandevuID;
            gncl.RandevuTarihi = p1.RandevuTarihi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}