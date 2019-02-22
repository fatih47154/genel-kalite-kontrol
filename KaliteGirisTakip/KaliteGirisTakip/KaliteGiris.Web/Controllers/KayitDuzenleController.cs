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
    public class KayitDuzenleController : Controller
    {
        LabDataModel db = new LabDataModel();

        public LabTalepManager LabTalepManager { get; set; }
        public KayitDuzenle KayitDuzenle { get; set; }
        public KDuzenle KDuzenle { get; set;}
        // GET: KayitDuzenle
        public ActionResult kayitDuzenle(Guid id)
        {
            KDuzenle Kayit = new KDuzenle();
            Kayit.LabList = db.LabTalep.FirstOrDefault(x => x.LabTalepId == id);
            Kayit.FirmaList = db.Firma.Where(x => x.IsActive == true).ToList();
            Kayit.AlimTipiList = db.AlimTipi.Where(x => x.IsActive == true).ToList();
            Kayit.DurumList = db.Durum.Where(x => x.IsActive == true).ToList();
            Kayit.PersonelList = db.Personel.ToList();

            var veri = db.LabTalep.FirstOrDefault(x => x.LabTalepId == id);
            var firma = db.Firma.Where(x => x.IsActive == true).ToList();
            var alimTipi = db.AlimTipi.Where(x => x.IsActive == true).ToList();
            var durum = db.Durum.Where(x => x.IsActive == true).ToList();
            var personel = db.Personel.ToList();
            ViewBag.personel = personel;
            ViewBag.durum = durum;
            ViewBag.alimTipi = alimTipi;
            ViewBag.firma = firma;
            ViewBag.veri = veri;

            return View();
        }

        [HttpPost]
        public ActionResult kayitDuzenle(LabTalep veri)
        {
            string mesaj;
            veri.IsActive = true;
            string date = DateTime.Now.ToString();
            veri.UpdatededDate = Convert.ToDateTime(date);
            KayitDuzenle = new KayitDuzenle();
            int sonuc = KayitDuzenle.kayitDuzenle(veri); 
            if(sonuc == 1)
            {
                TempData["b"] = 1;
                mesaj = veri.SozlesmeNo + " Sözleşme Numaralı Talep Bilgisi Güncelledi.";
            }
            else
            {
                TempData["c"] = 1;
                mesaj = veri.SozlesmeNo + " Sözleşme Numaralı Talep Bilgisi Güncellenirken Hata Oluştu.";
            }
            TempData["a"] = mesaj;
            
            return RedirectToAction("kayitListele", "KayıtListele");
        }


    }
}