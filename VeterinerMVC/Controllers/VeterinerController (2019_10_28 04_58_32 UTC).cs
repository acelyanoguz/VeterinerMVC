using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web.Mvc;
using VeterinerMVC.Models;
using VeterinerMVC.Models.EntityFramework;

namespace VeterinerMVC.Controllers
{
    public class VeterinerController : Controller
    {
        HastaTakipEntities db = new HastaTakipEntities();
        // GET: Home
        public ActionResult Anasayfa()
        {
            return View();
        }

        public JsonResult Takvim()
        {
            List<Takvim> eventItems = new List<Takvim>();
            int kullaniciId = Convert.ToInt32(Session["id"].ToString());
            var takvims = db.Randevular.Where(x => x.KullaniciID == kullaniciId).ToList();
            foreach (var takvim in takvims)
            {
                DateTime dates = (DateTime)takvim.RandevuTarihi;
                Takvim item = new Takvim();
                item.id = takvim.RandevuID;
                item.title = takvim.Hayvan.HayvanAdi+" için randevu";
                item.start = dates.ToString("yyyy-MM-dd");
                item.end = dates.ToString("yyyy-MM-dd");
                eventItems.Add(item);
            }

            return Json(eventItems, JsonRequestBehavior.AllowGet);

        }

            }
        }

