using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KaliteGiris.Bll;
using KaliteGiris.Entities;

namespace KaliteGiris.UITest
{
    /// <summary>
    /// Summary description for DurumTest
    /// </summary>
    [TestClass]
    public class DurumTest
    {
        public DurumTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        
        [TestMethod]
        public void TestMethodDurumList()
        {
            DurumManager bll = new DurumManager();
            List<Durum> list = bll.DurumListele();
            Assert.AreNotEqual(list.Count, null);
        }

        [TestMethod]
        public void TestMethodDurumAdd()
        {
            Durum durum = new Durum();

            DurumTipi durumTipi = new DurumTipi();
            durumTipi.DurumTipiId=new Guid("52a930a1-f48f-e811-8e17-001cc0c1464b");


            durum.DurumAdi = "eposta ile gönderildi";
            durum.DurumTipiId = durumTipi.DurumTipiId;
           // durum.DurumTipi = durumTipi;


            DurumManager bll = new DurumManager();
            int result = bll.DurumEkle(durum);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethodDurumUpdate()
        {
            Durum durum= new Durum();

            durum.DurumId = new Guid("a3a07188-a690-e811-8e17-001cc0c1464b");
            
            durum.DurumAdi = "XXXX";
            durum.DurumTipiId = new Guid("52a930a1-f48f-e811-8e17-001cc0c1464b");

            DurumManager bll = new DurumManager();
            int result = bll.DurumGuncelle(durum);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethodDurumDelete()
        {
            
        }
    }
}
