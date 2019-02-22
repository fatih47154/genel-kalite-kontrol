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
    public class KayitSilController : Controller
    {
        // GET: KayitSil
        public ActionResult kayitSil(Guid id)
        {
            LabDataModel db = new LabDataModel();
            var veri = db.LabTalep.FirstOrDefault(x => x.LabTalepId == id);
            veri.IsActive = false;
            db.SaveChanges();
            return RedirectToAction("kayitListele", "KayıtListele"); 
        }
    }
}