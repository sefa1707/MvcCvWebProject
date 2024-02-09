using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using MvcCvWebProject.Models.Entity;

namespace MvcCvWebProject.Controllers
{
    [AllowAnonymous]
    public class VitrinController : Controller
    {
        // GET: Vitrin
        MvcCvDbEntities db = new MvcCvDbEntities();
        public ActionResult Index()
        {
            var hakkimda = db.TblHakkimda.ToList();
            return View(hakkimda);
        }

        public PartialViewResult Deneyim()
        {
            var deneyim = db.TblDeneyim.ToList();
            return PartialView(deneyim);
        }
        public ActionResult Egitim()
        {
            var egitim = db.TblEgitim.ToList();
            return PartialView(egitim);
        }

        public PartialViewResult Yetenek()
        {
            var yetenek = db.TblYetenek.ToList();
            return PartialView(yetenek);
        }

        public PartialViewResult Hobi()
        {
            var hobi = db.TblHobi.ToList();
            return PartialView(hobi);
        }

        public PartialViewResult Sertifika()
        {
            var sertifika = db.TblSertifika.ToList();
            return PartialView(sertifika);
        }
        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim(Tbliletisim i)
        {
            i.iletisimTarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbliletisim.Add(i);
            db.SaveChanges();
            return PartialView();
        }

        public PartialViewResult SosyalMedya()
        {
            var sosyal= db.TblSosyalMedya.Where(x => x.SosyalDurum == true).ToList();
            return PartialView(sosyal);
        }
    }
}