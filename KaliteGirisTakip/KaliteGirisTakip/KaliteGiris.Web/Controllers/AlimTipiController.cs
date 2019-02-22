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
    public class AlimTipiController : Controller
    {
        private LabDataModel db = new LabDataModel();
        public AlimTipiManager AlimTipiManager { get; set; }
        public List<AlimTipi> ListAlimTipi { get; set; }
        // GET: AlimTipi
        public ActionResult AlimTipiIslemleri()
        {
            AlimTipiManager = new AlimTipiManager();

            ListAlimTipi = AlimTipiManager.AlimTipiListele();
            ViewBag.ListAlimTipi = ListAlimTipi;
            return View();
        }

        [HttpPost]
        public ActionResult AlimTipiEkle(AlimTipi veri)
        {
            AlimTipiManager = new AlimTipiManager();
            string mesaj;
            int sonuc = AlimTipiManager.AlimTipiEkle(veri);
            if(sonuc == 1)
            {
                mesaj = "Girdiğiniz Alım Tipi Başarı ile Kaydedildi.";
                TempData["b"] = 1;
            }
            else
            {
                TempData["c"] = 1;
                mesaj = "Girdiğiniz Alım Tipi Kaydedilirken Hata Oluştu";
            }
            TempData["a"] = mesaj;
            return RedirectToAction("AlimTipiIslemleri");
        }

        public ActionResult AlimTipiDuzenle(Guid id)
        {
            var veri = db.AlimTipi.FirstOrDefault(x => x.AlimTipiId == id);
            ViewBag.veri = veri;
            return View("AlimTipiIslemleri");
        }

    }
}