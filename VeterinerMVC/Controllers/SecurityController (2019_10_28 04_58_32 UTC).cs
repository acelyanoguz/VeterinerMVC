using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VeterinerMVC.Models.EntityFramework;

namespace VeterinerMVC.Controllers
{
    public class SecurityController : Controller
    {
     
        HastaTakipEntities db = new HastaTakipEntities();
        // GET: Security
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Profil kullanici)
        {
            var kullaniciInDb = db.Profil.Where(x => x.KullaniciAdi == kullanici.KullaniciAdi && x.KullaniciSifre == kullanici.KullaniciSifre).FirstOrDefault();
            if(kullaniciInDb!=null)
            {
                FormsAuthentication.SetAuthCookie(kullaniciInDb.KullaniciAdi + " " + kullaniciInDb.KullaniciSoyad, false);
                Session["id"] = kullaniciInDb.KullaniciID;
                Session["adsoyad"] = kullaniciInDb.KullaniciAdi + " " + kullaniciInDb.KullaniciSoyad;
               
                return RedirectToAction("Anasayfa", "Veteriner");
              
            }
            else
            {
                //ViewBag.Mesaj = "Geçersiz Kullanıcı Adı veya Şifre";
                TempData["msg"] = "<script>alert('Geçersiz Kullanıcı Adı veya Şifre');</script>";
                
                return View();
            }
        }
        public ActionResult Logout()
        {            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [AllowAnonymous]
        public ActionResult YeniUyelik()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult YeniUyelik(Profil user)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniUyelik");
            }
            db.Profil.Add(user);
            db.SaveChanges();
            return View();

        }
        
        public ActionResult KullaniciInfo()
        {
            string kullaniciid = Session["id"].ToString();
            int a = Convert.ToInt32(kullaniciid);
            var bilgi = db.Profil.Find(a);
            return View("KullaniciInfo", bilgi);
           
        }
        
        public ActionResult Guncelle(Profil p1)
        {
            if (!ModelState.IsValid)
            {
                return View("KullaniciInfo");
            }
            var gncl = db.Profil.Find(p1.KullaniciID);
            gncl.KullaniciAdi = p1.KullaniciAdi;
            gncl.KullaniciMail = p1.KullaniciMail;
            gncl.KullaniciSoyad = p1.KullaniciSoyad;
            gncl.KullaniciSifre = p1.KullaniciSifre;
            db.SaveChanges();
            return RedirectToAction("KullaniciInfo");
        }
      
    }
}