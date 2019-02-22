using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KaliteGiris.Bll;
using KaliteGiris.Entities;

namespace KaliteGiris.UITest
{
    /// <summary>
    /// Summary description for FirmaTest
    /// </summary>
    [TestClass]
    public class FirmaTest
    {
        public FirmaTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [TestMethod]
        public void TestMethodFirmaList()
        {
            FirmaManager bll = new FirmaManager();
            List<Firma> list = bll.FirmaListele();
            Assert.AreNotEqual(list.Count, null);
        }
        [TestMethod]
        public void TestMethodFirmaAdd()
        {

            Firma firma = new Firma();

            firma.FirmaAdi = "X Firması";
            firma.IsActive = true;

            FirmaManager bll = new FirmaManager();
            int result = bll.FirmaEkle(firma);
            Assert.AreEqual(result, 1);
        }
        [TestMethod]
        public void TestMethodFirmaUpdate()
        {
            Firma firma = new Firma();
            
            firma.FirmaAdi = "CCC Firması";
            firma.IsActive = true;
            firma.FirmaId = new Guid("a6143f4f-688e-e811-8e13-001cc0c1464b");

            FirmaManager bll = new FirmaManager();
            int result = bll.FirmaGuncelle(firma);
            Assert.AreEqual(result, 1);
        }
        [TestMethod]
        public void TestMethodFirmaDelete()
        {
            Firma firma = new Firma();

            firma.FirmaId = new Guid("a6143f4f-688e-e811-8e13-001cc0c1464b");

            FirmaManager bll = new FirmaManager();
            int result = bll.FirmaSil(firma.FirmaId);
            Assert.AreEqual(result, 1);
        }
    }
}
