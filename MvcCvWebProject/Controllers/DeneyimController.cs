using MvcCvWebProject.Models.Entity;
using MvcCvWebProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCvWebProject.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult Index()
        {
            var deneyim = repo.List();
            return View(deneyim);

        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyim d)
        {
            repo.TAdd(d);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            TblDeneyim t=repo.Find(x=>x.DeneyimID==id);
            repo.TDelete(t);    
            return RedirectToAction("Index");

        }
       
        public ActionResult DeneyimGetir(int id)
        {
            TblDeneyim t = repo.Find(x => x.DeneyimID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(TblDeneyim d)
        {
            TblDeneyim deneyim = repo.Find(x => x.DeneyimID == d.DeneyimID);
            deneyim.DeneyimUnvan = d.DeneyimUnvan;
            deneyim.DeneyimKurulus = d.DeneyimKurulus;
            deneyim.DeneyimAciklama=d.DeneyimKurulus;
            deneyim.DeneyimBaslangicTarih = d.DeneyimBaslangicTarih;
            deneyim.DeneyimBitisTarih=d.DeneyimBitisTarih;
            repo.TUpdate(deneyim);
            return RedirectToAction("Index");   
        }

    }
}