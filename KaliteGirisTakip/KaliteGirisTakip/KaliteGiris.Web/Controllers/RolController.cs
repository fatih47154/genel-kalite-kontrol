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
    public class RolController : Controller
    {
        private LabDataModel db = new LabDataModel();
        public MenuRoleManager MenuRoleManager { get; set; }
        public List<NavigationMenuRole> ListMenuRole { get; set; }

        public MenuManager MenuManager { get; set; }
        public List<NavigationMenu> ListMenu { get; set; }

        // GET: Rol
        public ActionResult RolIslemleri()
        {
            MenuRoleManager = new MenuRoleManager();
            ListMenuRole = MenuRoleManager.MenuRoleListele();

            MenuManager = new MenuManager();
            ListMenu = MenuManager.MenuListele();

            List<Role> ListRol = db.Role.ToList();

            ViewBag.ListMenu = ListMenu;
            ViewBag.ListMenuRole = ListMenuRole;
            ViewBag.ListRol = ListRol;
            return View();
        }

        [HttpPost]
        public ActionResult RolAta(NavigationMenuRole veri)
        {
            MenuRoleManager = new MenuRoleManager();
            string mesaj;
            int sonuc = MenuRoleManager.RolAta(veri);
            if (sonuc == 1)
            {
                mesaj = "Yaptığınız Yetkilendirme Başarı İle Kaydedildi.";
                TempData["b"] = 1;
            }
            else
            {
                TempData["c"] = 1;
                mesaj = "Yaptığınız Yetkilendirme Kaydedilirken Bir Hata Ortaya Çıktı !!";
            }
            TempData["a"] = mesaj;
            return RedirectToAction("RolIslemleri");
        }

        public ActionResult RolDuzenle(Guid id)
        {
            MenuRoleManager = new MenuRoleManager();
            MenuManager = new MenuManager();

            List<Role> ListRol = db.Role.ToList();
            ListMenuRole = MenuRoleManager.MenuRoleListele();
            ListMenu = MenuManager.MenuListele();

            ViewBag.ListRol = ListRol;
            ViewBag.ListMenuRole = ListMenuRole;
            ViewBag.ListMenu = ListMenu;

            var veri = db.NavigationMenuRole.FirstOrDefault(x => x.MenuRolId == id);
            ViewBag.veri = veri;
            TempData["d"] = 1;
            return View("RolIslemleri");
        }

        [HttpPost]
        public ActionResult RolDuzenle(NavigationMenuRole veri)
        {
            veri.IsActive = true;
            string mesaj;
            MenuRoleManager = new MenuRoleManager();
            int sonuc = MenuRoleManager.MenuRoleDuzenle(veri);
            if(sonuc == 1)
            {
                mesaj = "Yaptığınız Yetkilendirme Başarı ile Güncellendi.";
                TempData["b"] = 1;
            }
            else
            {
                TempData["c"] = 1;
                mesaj = "Yaptığınız Yetkilendirme Güncellenirken Bir Hata Ortaya Çıktı";
            }
            TempData["a"] = mesaj;
            return RedirectToAction("RolIslemleri");
        }

        public ActionResult MenuRolSil(Guid id)
        {
            MenuRoleManager = new MenuRoleManager();
            string mesaj;
            int sonuc = MenuRoleManager.MenuRoleSil(id);
            if (sonuc == 1)
            {
                mesaj = "Seçtiğiniz Yetkilendirme Başarı ile Silindi";
                TempData["b"] = 1;
            }
            else
            {
                TempData["c"] = 1;
                mesaj = "Seçtiğiniz Yetkilendirme Silinirken Bir Hata Ortaya Çıktı !!!";
            }
            TempData["a"] = mesaj;
            return RedirectToAction("RolIslemleri");
        }

    }
}