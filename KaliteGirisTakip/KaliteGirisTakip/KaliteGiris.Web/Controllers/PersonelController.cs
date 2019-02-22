using KaliteGiris.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaliteGiris.Web.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        public ActionResult Index()
        {
            ServiceReferenceIK.ServicePersonelClient service = new ServiceReferenceIK.ServicePersonelClient();
            //var list = service.GetPersonelBilgiList();

            return View();
        }
    }
}