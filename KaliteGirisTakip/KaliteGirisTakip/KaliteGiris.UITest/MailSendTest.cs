using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailSending;
using KaliteGiris.Entities;
using KaliteGiris.EfDal;
using KaliteGiris.Bll;

namespace KaliteGiris.UITest
{

    [TestClass]
    public class MailSendTest
    {
        public MailSendTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }    
        [TestMethod]
        public void TestMethodMailSendTest()
        {
            Personel personel = new Personel();
            personel.Email = "nbstrk@gmail.com";
            personel.Adi = "Nefise";
            personel.Soyadi = "Baştürk";

            
            PersonelManager personelManager = new PersonelManager();
            bool result =personelManager.MailGonder(personel);

            Assert.AreEqual(result, true);            
        }

        [TestMethod]
        public void TestMethodMultiMailSendTest()
        {
            Personel personel = new Personel();

            personel.Email = "nbstrk@gmail.com";
            personel.Adi = "Nefise";
            personel.Soyadi = "Baştürk";
            
            PersonelManager personelManager = new PersonelManager();
            bool result = personelManager.MailGonder(personel);
            Assert.AreEqual(result, true);
        }
    }
}
