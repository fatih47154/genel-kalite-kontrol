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
    public class YeniKayitController : Controller
    {
        public LabTalepManager LabTalepManager { get; set; }
        public List<LabTalep> listLab { get; set; }
        private int siraArtis()
        {
            LabTalepManager = new LabTalepManager();
            listLab = LabTalepManager.LabTalepListele();
            int yeniSira;
            int baslangic = 0;
            if (listLab != null)
            {
                foreach (var item in listLab)
                {
                    if (item.Sira > baslangic)
                    {
                        baslangic = item.Sira;
                    }
                }
            }

            yeniSira = baslangic + 1;
            return yeniSira;
        }

        LabDataModel db = new LabDataModel();
        // GET: YeniKayit
        public ActionResult yeniKayit()
        {
            
            var firma = db.Firma.Where(x => x.IsActive == true).ToList();
            var personel = db.Personel.ToList();
            var durum = db.Durum.Where(x => x.IsActive == true).ToList();
            var alimTipi = db.AlimTipi.Where(x => x.IsActive == true).ToList();

            ViewBag.firma = firma;
            ViewBag.personel = personel;
            ViewBag.durum = durum;
            ViewBag.alimTipi = alimTipi;
            return View();
        }

        [HttpPost]
        public ActionResult yeniKayit(LabTalep veri)
        {
            string date = DateTime.Now.ToString();
            string mesaj;
            veri.CreatedDate = Convert.ToDateTime(date);
            veri.IsActive = true;
            veri.Sira = siraArtis();
            try
            { 
                db.LabTalep.Add(veri);
                db.SaveChanges();
                mesaj = veri.SozlesmeNo + " Sözleşme Numaralı Talep Bilgisi Kaydedildi.";
                TempData["b"] = 1;
            }
            catch
            {
                mesaj = veri.SozlesmeNo + " Sözleşme Numaralı Talep Bilgisi Kaydedilirken Hata Oluştu.";
                TempData["c"] = 1;
            }
            TempData["a"] = mesaj;
            return RedirectToAction("kayitListele", "KayıtListele");
        }
    }
}