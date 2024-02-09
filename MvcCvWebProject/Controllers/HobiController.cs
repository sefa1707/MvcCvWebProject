using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvWebProject.Models.Entity;
using MvcCvWebProject.Repositories;

namespace MvcCvWebProject.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        HobiRepository repo = new HobiRepository();
        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpPost]
        public ActionResult Index(TblHobi h)
        {
            var t = repo.Find(x => x.HobiID == 1);
            t.HobiAciklama1 = h.HobiAciklama1;
            t.HobiAciklama2 = h.HobiAciklama2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}