using MvcCvWebProject.Models.Entity;
using MvcCvWebProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCvWebProject.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        GenericRepository<TblKullanici> repo = new GenericRepository<TblKullanici>();
        [HttpGet]
        public ActionResult Index()
        {
            var kullanici = repo.List();
            return View(kullanici);
        }
        [HttpPost]
        public ActionResult Index(TblKullanici k)
        {
            var kullanici = repo.Find(x => x.KullaniciID == 1);
            kullanici.KullaniciAdi = k.KullaniciAdi;
            kullanici.KullaniciSifre = k.KullaniciSifre;
            repo.TUpdate(kullanici);
            return RedirectToAction("Index");
        }
    }
}