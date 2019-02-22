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
    public class FirmaController : Controller
    { 
        LabDataModel db = new LabDataModel();
        public FirmaManager FirmaManager { get; set; }
        public List<Firma> ListFirma { get; set; }

        // GET: Firma
        //[Authorize(Roles = "Admin")]
        public ActionResult FirmaIslemleri()
        {
            FirmaManager = new FirmaManager();

            ListFirma = FirmaManager.FirmaListele();
            ViewBag.ListFirma = ListFirma;
            return View();
        }

        public ActionResult FirmaDuzenle(Guid id)
        {
            FirmaManager = new FirmaManager();

            ListFirma = FirmaManager.FirmaListele();
            ViewBag.ListFirma = ListFirma;

            var veri = db.Firma.FirstOrDefault(x => x.FirmaId == id);
            ViewBag.veri = veri;
            TempData["d"] = 1;
            return View("FirmaIslemleri");
        }

        [HttpPost]
        public ActionResult FirmaDuzenle(Firma veri)
        {
            string mesaj;
            FirmaManager = new FirmaManager();
            int sonuc = FirmaManager.FirmaGuncelle(veri);
            if(sonuc == 1)
            {
                mesaj = "Girdiğiniz Firma Başarı ile Güncellendi.";
                TempData["b"] = 1;
            }
            else
            {
                TempData["c"] = 1;
                mesaj = "Girdiğiniz Firma Güncellenirken Bir Hata Ortaya Çıktı !!!";
            }
            TempData["a"] = mesaj;
            return RedirectToAction("FirmaIslemleri");
        }

        [HttpPost]
        public ActionResult FirmaEkle(Firma veri)
        {
            FirmaManager = new FirmaManager();
            string mesaj;
            int sonuc = FirmaManager.FirmaEkle(veri);
            if(sonuc == 1)
            {
                mesaj = "Seçtiğiniz Firma Başarı ile Kaydedildi.";
                TempData["b"] = 1;
            }
            else
            {
                TempData["c"] = 1;
                mesaj = "Seçtiğiniz Firma Kaydedilirken Bir Hata Ortaya Çıktı !!!";
            }
            TempData["a"] = mesaj;
            return RedirectToAction("FirmaIslemleri");
        }

        public ActionResult FirmaSil(Guid id)
        {
            
            FirmaManager = new FirmaManager();
            string mesaj;
            //var veri = db.Firma.FirstOrDefault(x => x.FirmaId == id);
            int sonuc = FirmaManager.FirmaSil(id);
            //db.Firma.Remove(veri);

            if (sonuc == 1)
            {
                mesaj = "Seçtiğiniz Firma Başarı ile Silindi";
                TempData["b"] = 1;
            }
            else if (sonuc == 2)
            {
                TempData["e"] = 1;
                mesaj = "Seçtiğiniz Firma Talep Tablosunda Bir Veri Tarafından Kullanılmaktadır !!! !!!";
                TempData["id"] = id;
            }
            else
            {
                TempData["c"] = 1;
                mesaj = "Seçtiğiniz Firma Silinirken Bir Hata Ortaya Çıktı !!!";
            }
            TempData["a"] = mesaj;
            return RedirectToAction("FirmaIslemleri");
        }

        public ActionResult Goster(Guid id)
        {
            List<LabTalep>olanVeri = db.LabTalep.Where(z => z.FirmaId == id).ToList();
            ViewBag.listlab = olanVeri;
            TempData["Tümünü Göster"] = 1;
            return View("../KayıtListele/kayitListele");
        }
    }
}