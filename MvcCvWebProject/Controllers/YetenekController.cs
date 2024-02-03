using MvcCvWebProject.Models.Entity;
using MvcCvWebProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCvWebProject.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        YetenekRepository repo = new YetenekRepository();
        public ActionResult Index()
        {
            var yetenek = repo.List();
            return View(yetenek);
        }
        [HttpGet]
        public ActionResult YetenekEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult YetenekEkle(TblYetenek y)
        {
            repo.TAdd(y);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            TblYetenek y = repo.Find(x => x.YetenekID == id);
            repo.TDelete(y);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            TblYetenek yetenek = repo.Find(x => x.YetenekID == id);
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult YetenekGetir(TblYetenek y)
        {
            TblYetenek yetenek = repo.Find(x => x.YetenekID == y.YetenekID);
            yetenek.YetenekAciklama = y.YetenekAciklama;
            yetenek.YetenekOran = y.YetenekOran;
            repo.TUpdate(yetenek);
            return RedirectToAction("Index");
        }

    }
}