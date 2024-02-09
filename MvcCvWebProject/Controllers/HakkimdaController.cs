using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvWebProject.Models.Entity;
using MvcCvWebProject.Repositories;

namespace MvcCvWebProject.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        HakkimdaRepository repo=new HakkimdaRepository();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(TblHakkimda h)
        {
            var t = repo.Find(x => x.HakkimdaID == 1);
            t.HakkimdaAd = h.HakkimdaAd;
            t.HakkimdaSoyad = h.HakkimdaSoyad;
            t.HakkimdaAdres = h.HakkimdaAdres;
            t.HakkimdaTelefon = h.HakkimdaTelefon;
            t.HakkimdaMail = h.HakkimdaMail;
            t.HakkimdaAciklama = h.HakkimdaAciklama;
            t.HakkimdaGorsel = h.HakkimdaGorsel;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}