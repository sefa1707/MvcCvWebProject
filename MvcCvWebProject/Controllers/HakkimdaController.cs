using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvWebProject.Repositories;

namespace MvcCvWebProject.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        HakkimdaRepository repo=new HakkimdaRepository();
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }
    }
}