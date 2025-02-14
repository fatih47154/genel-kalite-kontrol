﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KaliteGiris.Bll;
using System.Collections.Generic;
using KaliteGiris.Entities;

namespace KaliteGiris.UITest
{
    [TestClass]
    public class LabTalepTest
    {
        //list
        [TestMethod]
        public void TestMethodLabList()
        {
            LabTalepManager bll = new LabTalepManager();
            List<LabTalep> list = bll.LabTalepListele();
            Assert.AreEqual(list.Count, 0);
        }
        [TestMethod]
        public void TestMethodLabTalepAdd()
        {

            LabTalep lapTalep = new LabTalep();

            lapTalep.Sira = 1003;
            lapTalep.Tarih = DateTime.Now;
            lapTalep.RaporTarihi = DateTime.Now;
            lapTalep.FirmaId = new Guid("bdfb7d95-e88f-e811-8e16-001cc0c1464b");
            lapTalep.SozlesmeNo = "9011";
            lapTalep.AlimTipiId = new Guid("60e89c0a-63a0-e811-8ee1-408d5ca6bf05");
            lapTalep.Malzeme = "vida";
            lapTalep.IrsaliyeNo = "8010";
            lapTalep.PersonelId= new Guid("8cd6e525-a190-e811-8e17-001cc0c1464b");
            lapTalep.DurumId= new Guid("725051d5-aa90-e811-8e17-001cc0c1464b");
            lapTalep.Aciklama = "sssssss";


            LabTalepManager bll = new LabTalepManager();
            int result = bll.LabTalepEkle(lapTalep);
            Assert.AreEqual(result, 1);
        }
        [TestMethod]
        public void TestMethodLabTalepDelete()
        {
            LabTalep lapTalep = new LabTalep();

            lapTalep.LabTalepId = new Guid("22f2f017-ad90-e811-8e17-001cc0c1464b");

            LabTalepManager bll = new LabTalepManager();
            int result = bll.LabTalepSil(lapTalep);
            Assert.AreEqual(result, 1);
        }
        [TestMethod]
        public void TestMethodLabTalepUpdate()
        {
            LabTalep lapTalep = new LabTalep();


            lapTalep.LabTalepId = new Guid("f712f7e1-ac90-e811-8e17-001cc0c1464b");

            lapTalep.Sira = 1003;
            lapTalep.Tarih = new DateTime(2017, 7, 30);
            lapTalep.RaporTarihi = DateTime.Now;
            lapTalep.FirmaId = new Guid("bdfb7d95-e88f-e811-8e16-001cc0c1464b");
            lapTalep.SozlesmeNo = "9011";
            lapTalep.AlimTipiId = new Guid("60e89c0a-63a0-e811-8ee1-408d5ca6bf05");
            lapTalep.Malzeme = "vida";
            lapTalep.IrsaliyeNo = "8010";
            lapTalep.PersonelId = new Guid("8cd6e525-a190-e811-8e17-001cc0c1464b");
            lapTalep.DurumId = new Guid("725051d5-aa90-e811-8e17-001cc0c1464b");
            lapTalep.Aciklama = "sssssss";

            LabTalepManager bll = new LabTalepManager();
            int result = bll.LabTalepGuncelle(lapTalep);
            Assert.AreEqual(result, 1);
        }

    }
}
