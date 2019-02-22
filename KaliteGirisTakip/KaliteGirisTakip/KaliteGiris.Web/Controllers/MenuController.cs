using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KaliteGiris.Bll;
using KaliteGiris.Entities;
using KaliteGiris.EfDal;

namespace KaliteGiris.Web.Controllers
{
    public class MenuController : Controller
    {
        LabDataModel db = new LabDataModel();
        public MenuManager MenuManager { get; set; }
        public MenuRoleManager MenuRoleManager { get; set; }
        public List<NavigationMenu> ListMenu { get; set; }
        public List<NavigationMenuRole> ListMenuRole { get; set; }
        // GET: Menu
        public ActionResult Menu(Personel veri)
        {
            MenuManager = new MenuManager();
            MenuRoleManager = new MenuRoleManager();

            ListMenuRole = MenuRoleManager.MenuRoleListele();
            ListMenu = MenuManager.MenuListele();

            ViewBag.Kullanici = veri;
            ViewBag.ListMenuRole = ListMenuRole;
            ViewBag.ListMenu = ListMenu;
            
            return View();
        }


    }
}