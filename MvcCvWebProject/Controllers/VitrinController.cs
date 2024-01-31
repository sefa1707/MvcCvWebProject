using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvWebProject.Models.Entity;

namespace MvcCvWebProject.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        MvcCvDbEntities db=new MvcCvDbEntities();   
        public ActionResult Index()
        {
            var hakkimda = db.TblHakkimda.ToList();
            return View(hakkimda);
        }
    }
}