using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeterinerMVC.Models.EntityFramework;

namespace VeterinerMVC.Controllers
{
    public class HastalarController : Controller
    {
        HastaTakipEntities db = new HastaTakipEntities();
        // GET: Hastalar
        public ActionResult Index(Hayvan hayvan)

        {
          
          

            string kullaniciid = Session["id"].ToString();
            int a = Convert.ToInt32(kullaniciid);
            var hastalar = db.Hayvan.Where(x => x.KullaniciID == a).ToList();// kullanıcıya özel
            return View(hastalar);
        }
    }
}