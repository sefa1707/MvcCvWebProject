using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvWebProject.Models.Entity;
using MvcCvWebProject.Repositories;

namespace MvcCvWebProject.Controllers
{
    public class SosyalController : Controller
    {
        // GET: Sosyal
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();
        public ActionResult Index()
        {
            var sosyal = repo.List();
            return View(sosyal);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya s)
        {
            s.SosyalDurum = true;
            repo.TAdd(s);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SosyalDuzenle(int id)
        {
            var sosyal = repo.Find(x => x.SosyalID == id);
            return PartialView(sosyal);
        }

        [HttpPost]
        public ActionResult SosyalDuzenle(TblSosyalMedya s)
        {
            TblSosyalMedya sosyal = repo.Find(x => x.SosyalID == s.SosyalID);
            sosyal.SosyalAd = s.SosyalAd;
            sosyal.SosyalLink = s.SosyalLink;
            sosyal.SosyalDurum = s.SosyalDurum;
            sosyal.Sosyalicon = s.Sosyalicon;
            repo.TUpdate(sosyal);
            return RedirectToAction("Index");
        }

        public ActionResult AktifYap(int id)
        {
            var sosyal = repo.Find(x => x.SosyalID == id);
            sosyal.SosyalDurum = true;
            repo.TUpdate(sosyal);
            return RedirectToAction("Index");
        }

        public ActionResult PasifYap(int id)
        {
            var sosyal = repo.Find(x => x.SosyalID == id);
            sosyal.SosyalDurum = false;
            repo.TUpdate(sosyal);
            return RedirectToAction("Index");
        }
    }
}