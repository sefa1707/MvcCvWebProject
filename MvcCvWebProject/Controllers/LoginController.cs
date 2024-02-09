using MvcCvWebProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCvWebProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblKullanici k)
        {
            MvcCvDbEntities db = new MvcCvDbEntities();
            var bilgi = db.TblKullanici.FirstOrDefault(x => x.KullaniciAdi == k.KullaniciAdi && x.KullaniciSifre == k.KullaniciSifre);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KullaniciAdi, false);
                Session["KullaniciAdi"] = bilgi.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Hakkimda");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}