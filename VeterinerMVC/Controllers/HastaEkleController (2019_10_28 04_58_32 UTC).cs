using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VeterinerMVC.Models.EntityFramework;

namespace VeterinerMVC.Controllers
{
    public class HastaEkleController : Controller
    {
        HastaTakipEntities db = new HastaTakipEntities();
        // GET: HastaEkle
        public ActionResult Index()
        {
            var adsoyad = HttpContext.User.Identity.Name;

            var model = db.Hayvan.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult YeniHasta()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniHasta(Hayvan hasta)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniHasta");
            }
            int c = Convert.ToInt32(Session["id"]);
            hasta.KullaniciID = c;

            db.Hayvan.Add(hasta);
            db.SaveChanges();

            var hayvan = db.Hayvan.OrderByDescending(x => x.HayvanID).FirstOrDefault();
           
            ViewBag.hasta = db.Hayvan.ToList();

            return RedirectToAction("Index", "HastaKarti", hayvan);

        }
        
    }
}