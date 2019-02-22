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
    public class DurumController : Controller
    {
        private LabDataModel db = new LabDataModel();
        public DurumManager DurumManager { get; set; }
        public DurumTipiManager DurumTipiManager { get; set; }
        public List<Durum> ListDurum { get; set; }
        public List<DurumTipi> ListDurumTipi { get; set; }
        // GET: Durum
        public ActionResult DurumIslemleri()
        {
            DurumManager = new DurumManager();
            DurumTipiManager = new DurumTipiManager();

            ListDurum = DurumManager.DurumListele();
            ListDurumTipi = DurumTipiManager.DurumTipiListele();

            ViewBag.ListDurum = ListDurum;
            ViewBag.ListDurumTipi = ListDurumTipi;

            return View();
        }

        public ActionResult DurumDuzenle(Guid id)
        {
            DurumManager = new DurumManager();

            
            DurumTipiManager = new DurumTipiManager();

            
            ListDurumTipi = DurumTipiManager.DurumTipiListele();

            
            ViewBag.ListDurumTipi = ListDurumTipi;

            ListDurum = DurumManager.DurumListele();
            ViewBag.ListDurum = ListDurum;

            var veri = db.Durum.FirstOrDefault(x => x.DurumId == id);
            ViewBag.veri = veri;
            TempData["d"] = 1;
            return View("DurumIslemleri");
        }

        [HttpPost]
        public ActionResult DurumDuzenle(Durum veri)
        {
            veri.IsActive = true;
            string mesaj;
            DurumManager = new DurumManager();
            int sonuc = DurumManager.DurumGuncelle(veri);
            if(sonuc == 1)
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
            return RedirectToAction("DurumIslemleri");
        }

        [HttpPost]
        public ActionResult DurumEkle(Durum veri)
        {
            DurumManager = new DurumManager();
            string mesaj;
            int sonuc = DurumManager.DurumEkle(veri);
            if(sonuc == 1)
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
            return RedirectToAction("DurumIslemleri");
        }

        public ActionResult DurumSil(Guid id)
        {
            DurumManager = new DurumManager();
            string mesaj;
            //var veri = db.Durum.FirstOrDefault(x => x.DurumId == id);
            int sonuc = DurumManager.DurumSil(id);
            //db.Durum.Remove(veri);
            //sonuc = db.SaveChanges();
            if (sonuc == 1)
            {
                mesaj = "Seçtiğiniz Durum Başarı ile Silindi";
                TempData["b"] = 1;
            }
            else if(sonuc == 2)
            {
                TempData["e"] = 1;
                mesaj = "Seçtiğiniz Durum Talep Tablosunda Bir Veri Tarafından Kullanılmaktadır !!!";
                TempData["id"] = id;
            }
            else
            {
                TempData["c"] = 1;
                mesaj = "Seçtiğiniz Durum Silinirken Bir Hata Ortaya Çıktı !!!";
            }
            TempData["a"] = mesaj;
            return RedirectToAction("DurumIslemleri");
        }

        public ActionResult Goster(Guid id)
        {
            List<LabTalep> olanVeri = db.LabTalep.Where(z => z.DurumId == id || z.SonucDurumId == id || z.GKKSonucId == id).ToList();
            ViewBag.listlab = olanVeri;
            TempData["Tümünü Göster"] = 1;
            return View("../KayıtListele/kayitListele");
        }
    }
}