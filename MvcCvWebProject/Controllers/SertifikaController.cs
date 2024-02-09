using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvWebProject.Repositories;
using MvcCvWebProject.Models.Entity;

namespace MvcCvWebProject.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        SertifikaRepository repo = new SertifikaRepository();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }

        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifika s)
        {
            repo.TAdd(s);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            TblSertifika sertifika=repo.Find(x=>x.SertifikaID==id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            TblSertifika sertifika = repo.Find(x => x.SertifikaID == id);
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifika s)
        {
            TblSertifika sertifika = repo.Find(x => x.SertifikaID == s.SertifikaID);
            sertifika.SertifikaAd = s.SertifikaAd;
            sertifika.SertifikaKurulus = s.SertifikaKurulus;
            sertifika.SertifikaTarih = s.SertifikaTarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }
    }
}