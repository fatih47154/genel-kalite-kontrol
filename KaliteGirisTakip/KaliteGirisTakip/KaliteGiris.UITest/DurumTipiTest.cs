﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KaliteGiris.Entities;
using KaliteGiris.Bll;

namespace KaliteGiris.UITest
{
    [TestClass]
    public class DurumTipiTest
    {
        public DurumTipiTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [TestMethod]
        public void TestMethodDurumTipiList()
        {
            DurumTipiManager bll = new DurumTipiManager();
            List<DurumTipi> list = bll.DurumTipiListele();
            Assert.AreNotEqual(list.Count, null);
        }

        [TestMethod]
        public void TestMethodDurumTipiAdd()
        {
            DurumTipi durumTipi = new DurumTipi();

            durumTipi.DurumTip = "eposta ile gönderildi";
            durumTipi.DurumTipiId = new Guid("c8ec8c98-f48f-e811-8e17-001cc0c1464b");

            DurumTipiManager bll = new DurumTipiManager();
            int result = bll.DurumTipiEkle(durumTipi);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethodDurumTipiUpdate()
        {
            DurumTipi durumTipi = new DurumTipi();

            durumTipi.DurumTipiId = new Guid("c2f031c3-9d90-e811-8e17-001cc0c1464b");
            durumTipi.DurumTip = "XXXX";

            DurumTipiManager bll = new DurumTipiManager();
            int result = bll.DurumTipiGuncelle(durumTipi);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethodDurumTipiDelete()
        {
            DurumTipi durumTipi = new DurumTipi();

            durumTipi.DurumTipiId = new Guid("c2f031c3-9d90-e811-8e17-001cc0c1464b");
            DurumTipiManager bll = new DurumTipiManager();
            int result = bll.DurumTipiSil(durumTipi.DurumTipiId);
            Assert.AreEqual(result, 1);
        }
    }
}
