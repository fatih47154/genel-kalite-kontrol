using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KaliteGiris.Entities;
using KaliteGiris.Bll;

namespace KaliteGiris.Web.Controllers
{
    public class LoginController : Controller
    {
        LoginManager LoginManager { get; set; }
        // GET: Login
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(string kullaniciAdi,string sifre)
        {
            Personel k;
            LoginManager = new LoginManager();
            k = LoginManager.Login(kullaniciAdi, sifre);
            if (k == null)
            {
                TempData["a"] = "Kullanıcı Bulunamadı !!";
                return View();
            }
            else
            {
                Session["Kullanici"] = k;
                return RedirectToAction("kayitListele", "KayıtListele");
            }
        }

        public ActionResult logOut()
        {
            Session.Abandon();
            return RedirectToAction("login");
        }
    }
}