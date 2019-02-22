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
    public class DurumTipiController : Controller
    {
        private LabDataModel db = new LabDataModel();
        public DurumTipiManager DurumTipiManager { get; set; }
        public List<DurumTipi> ListDurumTipi { get; set; }
        // GET: DurumTipi
        public ActionResult DurumTipiIslemleri()
        {
            DurumTipiManager = new DurumTipiManager();

            ListDurumTipi = DurumTipiManager.DurumTipiListele();
            ViewBag.ListDurumTipi = ListDurumTipi;
            return View();
        }

        public ActionResult DurumTipiDuzenle(Guid id)
        {
            DurumTipiManager = new DurumTipiManager();

            ListDurumTipi = DurumTipiManager.DurumTipiListele();
            ViewBag.ListDurumTipi = ListDurumTipi;

            var veri = db.DurumTipi.FirstOrDefault(x => x.DurumTipiId == id);
            ViewBag.veri = veri;
            TempData["d"] = 1;
            return View("DurumTipiIslemleri");
        }

        [HttpPost]
        public ActionResult DurumTipiDuzenle(DurumTipi veri)
        {
            string mesaj;
            veri.IsActive = true;
            DurumTipiManager = new DurumTipiManager();
            int sonuc = DurumTipiManager.DurumTipiGuncelle(veri);
            if (sonuc == 1)
            {
                mesaj = "Girdiğiniz Durum Başarı İle Güncellendi.";
                TempData["b"] = 1;
            }
            else
            {
                TempData["c"] = 1;
                mesaj = "Girdiğiniz Durum Güncellenirken Bir Hata Ortaya Çıktı !!!";
            }
            TempData["a"] = mesaj;
            return RedirectToAction("DurumTipiIslemleri");
        }

        [HttpPost]
        public ActionResult DurumTipiEkle(DurumTipi veri)
        {
            DurumTipiManager = new DurumTipiManager();
            string mesaj;
            int sonuc = DurumTipiManager.DurumTipiEkle(veri);
            if (sonuc == 1)
            {
                mesaj = "Sectiğiniz Durum Başarı İle Kaydedildi.";
                TempData["b"] = 1;
            }
            else
            {
                TempData["c"] = 1;
                mesaj = "Seçtiğiniz Firma Kaydedilirken Bir Hata Ortaya Çıktı !!";
            }
            TempData["a"] = mesaj;
            return RedirectToAction("DurumTipiIslemleri");
        }

        public ActionResult DurumTipiSil(Guid id)
        {
            DurumTipiManager = new DurumTipiManager();
            string mesaj;
            //var veri = db.Durum.FirstOrDefault(x => x.DurumId == id);
            int sonuc = DurumTipiManager.DurumTipiSil(id);
            //db.Durum.Remove(veri);
            //sonuc = db.SaveChanges();
            if (sonuc == 1)
            {
                mesaj = "Seçtiğiniz Durum Başarı ile Silindi";
                TempData["b"] = 1;
            }
            else if (sonuc == 2)
            {
                TempData["e"] = 1;
                mesaj = "Seçtiğiniz Durum Tipi, Durum Tablosunda Bir Veri Tarafından Kullanılmaktadır !!!";
                TempData["id"] = id;
            }
            else
            {
                TempData["c"] = 1;
                mesaj = "Seçtiğiniz Durum Tipi Silinirken Bir Hata Ortaya Çıktı !!!";
            }
            TempData["a"] = mesaj;
            return RedirectToAction("DurumTipiIslemleri");
        }

        public ActionResult Goster(Guid id)
        {
            List<Durum> olanVeri = db.Durum.Where(z => z.DurumTipiId == id).ToList();
            ViewBag.ListDurum = olanVeri;
            TempData["Tümünü Göster"] = 1;

            DurumTipiManager = new DurumTipiManager();

            ListDurumTipi = DurumTipiManager.DurumTipiListele();
            ViewBag.ListDurumTipi = ListDurumTipi;
            return View("../Durum/DurumIslemleri");
        }
    }

}
