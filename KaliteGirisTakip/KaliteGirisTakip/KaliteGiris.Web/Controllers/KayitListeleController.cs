﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KaliteGiris.Bll;
using KaliteGiris.Entities;
using KaliteGiris.EfDal;

namespace KaliteGiris
{
    public class KayıtListeleController : Controller
    {
        
        public LabTalepManager LabTalepManager { get; set; }
        public List<LabTalep> listLab { get; set; }
        // GET: KayıtListele
        public ActionResult kayitListele()
        {
            LabTalepManager = new LabTalepManager();

            listLab = LabTalepManager.LabTalepListele();
            return View(listLab);

        }
    }
}