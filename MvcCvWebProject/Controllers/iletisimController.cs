using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvWebProject.Models.Entity;
using MvcCvWebProject.Repositories;

namespace MvcCvWebProject.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        iletisimRepository repo=new iletisimRepository();
        public ActionResult Index()
        {
            var mesaj = repo.List();
            return View(mesaj);
        }
    }
}