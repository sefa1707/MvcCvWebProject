using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvWebProject.Models.Entity;
using MvcCvWebProject.Repositories;

namespace MvcCvWebProject.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        EgitimRepository repo = new EgitimRepository();
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitim e)
        {
            repo.TAdd(e);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            TblEgitim t = repo.Find(x => x.EgitimID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            TblEgitim e = repo.Find(x => x.EgitimID == id);
            return View(e);
        }
        [HttpPost]
        public ActionResult EgitimGetir(TblEgitim e)
        {
            TblEgitim egitim = repo.Find(x => x.EgitimID == e.EgitimID);
            egitim.EgitimOkulAd = e.EgitimOkulAd;
            egitim.EgitimBolumAd = e.EgitimBolumAd;
            egitim.EgitimAciklama = e.EgitimAciklama;
            egitim.EgitimGNO = e.EgitimGNO;
            egitim.EgitimBaslangicTarih = e.EgitimBaslangicTarih;
            egitim.EgitimBitisTarih = e.EgitimBitisTarih;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }


    }
}